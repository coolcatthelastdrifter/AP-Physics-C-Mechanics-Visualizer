using System.Collections.Generic;
using UnityEngine;

public class PlaceablesSystem : MonoBehaviour
{
    private Dictionary<string, GameObject> PlaceablePrefabs;

    void Awake()
    {
        PlaceablePrefabs = new Dictionary<string, GameObject>();

        foreach (GameObject prefab in Resources.LoadAll<GameObject>("Placeables"))
        {
            PlaceablePrefabs[prefab.name] = prefab;
            Debug.Log(prefab.name);
        }

        Debug.Log(PlaceablePrefabs["Block"]);
    }

    public bool TryPlacingPlaceable(string placeableName, Transform placementTransform, Dictionary<string, PlaceableProperty> optionsToChange)
    {
        if (PlaceablePrefabs.TryGetValue(placeableName, out GameObject prefab))
        {
            Instantiate(prefab, placementTransform.position, placementTransform.rotation);
            return true;
        }

        return false;
    }

    private void Start()
    {
        TryPlacingPlaceable("Block", gameObject.transform, new Dictionary<string, PlaceableProperty>());
    }
}