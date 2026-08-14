using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

public class PlaceablesSystem : MonoBehaviour
{
    public static PlaceablesSystem Instance { get; private set; }
    private GameObject currentGhostPlaceable;
    public bool InBuildMode = false;
    public Material GhostMaterialRed;
    public Material GhostMaterialGreen;
    public bool mouseControlForGhost = true;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!currentGhostPlaceable)
        {
            return;
        }

        if (currentGhostPlaceable.GetComponent<GhostValidityChecker>().IsValid)
        {
            currentGhostPlaceable.GetComponent<Renderer>().material = GhostMaterialGreen;
        }
        else
        {
            currentGhostPlaceable.GetComponent<Renderer>().material = GhostMaterialRed;
        }
    }
    public void EnterBuildMode()
    {
        if (InBuildMode)
        {
            return;
        }

        InBuildMode = true;
    }

    public void ExitBuildMode()
    {
        if (!InBuildMode)
        {
            return;
        }

        ClearCurrentGhostPlaceable();
        InBuildMode = false;
    }

    public void SetCurrentGhostPlaceable(string name)
    {
        PlacementResult result = CreatePlaceable(name, new Vector3(), new Quaternion(), true);

        if (result.placementSucess)
        {
            currentGhostPlaceable = result.placedObject;
        }
    }

    public void MoveOrRotateCurrentGhostPlaceable(Vector3 newPosition, Quaternion newRotation)
    {
        if (!currentGhostPlaceable)
        {
            return;
        }
        
        currentGhostPlaceable.transform.position = newPosition;
        currentGhostPlaceable.transform.rotation = newRotation;
    }

    public void ClearCurrentGhostPlaceable()
    {
        if (currentGhostPlaceable)
        {
            Destroy(currentGhostPlaceable);
        }

        currentGhostPlaceable = null;
    }

    public PlacementResult CreatePlaceable(string name, Vector3 position, Quaternion rotation, bool isGhost)
    {
        PlaceableData requestedPlaceableData = PlaceablesDatabase.Instance.PlaceableSOs[name];
        PlacementResult placementResult = new PlacementResult();
        GameObject prefabToClone;

        if (!requestedPlaceableData)
        {
            placementResult.placementSucess = false;
            placementResult.failureReason = "Placeable Name " + name + " was not found in Database!";
            return placementResult;
        }

        if (isGhost)
        {
            prefabToClone = requestedPlaceableData.prefabGhost;
        }
        else
        {
            prefabToClone = requestedPlaceableData.prefab;

            if (!currentGhostPlaceable)
            {
                placementResult.placementSucess = false;
                placementResult.failureReason = "No placeable ghost!";
                return placementResult;
            }

            if (!currentGhostPlaceable.GetComponent<GhostValidityChecker>().IsValid)
            {
                placementResult.placementSucess = false;
                placementResult.failureReason = "Invalid placement (not enough room)!";
                return placementResult;
            }
        }

        GameObject prefabClone = Instantiate(prefabToClone, position, rotation);

        placementResult.placementSucess = true;
        placementResult.placedObject = prefabClone;
        return placementResult;
    }
}
