using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PropertyFunctionEntry
{
    public string propertyName;
    public PlaceablePropertyFunction function;
}

[CreateAssetMenu]
public class PlaceablePropertyFunctionsDatabase : ScriptableObject
{
    public List<PropertyFunctionEntry> database = new();

    public PlaceablePropertyFunction Get(string propertyName)
    {
        foreach (var entry in database)
        {
            if (entry.propertyName == propertyName)
                return entry.function;
        }

        return null;
    }
}