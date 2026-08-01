using System.Collections.Generic;
using UnityEngine;

public class PlaceablesDatabase : MonoBehaviour
{
    public static PlaceablesDatabase Instance { get; private set; }

    private Dictionary<string, PlaceableData> placeableSOs;

    public IReadOnlyDictionary<string, PlaceableData> PlaceableSOs => placeableSOs;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        placeableSOs = new Dictionary<string, PlaceableData>();

        foreach (PlaceableData data in Resources.LoadAll<PlaceableData>("PlaceablesSOs"))
        {
            placeableSOs[data.name] = data;
        }
    }
}