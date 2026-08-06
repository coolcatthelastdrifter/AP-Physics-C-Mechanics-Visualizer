using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceablesPropertyHelper : MonoBehaviour
{
    public PlaceablePropertyFunctionsDatabase placeablePropertyFunctionsDatabase;
    void Start()
    {
        placeablePropertyFunctionsDatabase = Resources.Load<PlaceablePropertyFunctionsDatabase>("PlaceablePropertyFunctionsDatabase");
    }

    void Update()
    {
        
    }

    public void SetProperty(string propertyName, string propertyValue)
    {
        if (PlaceablesDatabase.Instance.PlaceableSOs.TryGetValue(gameObject.name, out PlaceableData data))
        {
            PlaceablePropertyFunction function = placeablePropertyFunctionsDatabase.Get(propertyName);
            if (data.changeableproperties.Contains(propertyName) && function != null)
            {
                function.Apply(gameObject, propertyValue);
            }
        }
        else
        {
            Debug.LogWarning(gameObject.name + " does not exist in the Database!");
        }
    }
}
