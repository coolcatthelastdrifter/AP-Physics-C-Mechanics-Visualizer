using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceablesSystem : MonoBehaviour
{
    private GameObject currentGhostPlaceable;

    public string TryPlacingPlaceable(string placeableName, Vector3 position, Quaternion rotation, Dictionary<string, string> optionsToChange){
        if (PlaceablesDatabase.Instance.PlaceableSOs.TryGetValue(placeableName, out PlaceableData data)){
            Instantiate(data.prefab, position, rotation);

            return "Placed Successfully";
        }
        else{
            Debug.LogWarning(placeableName + " doesn't exist in PlaceableDatabase!");
            return placeableName + " doesn't exist in PlaceableDatabase!";
        }
    }

    public void CreateOrMovePlaceableGhost(string placeableName, Vector3 position, Quaternion rotation)
    {
        if (PlaceablesDatabase.Instance.PlaceableSOs.TryGetValue(placeableName, out PlaceableData data)){
            Instantiate(data.prefab, position, rotation);

        }
        else{
            Debug.Log("FINISH THIS");
        }
    }

    void Start()
    {
        TryPlacingPlaceable("Block", new Vector3(0f, 10f, 0f), Quaternion.identity,new Dictionary<string, string>
{
    { "Color", "Red" },
    { "Mass", "10" }
});
    }
}
