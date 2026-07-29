using System.Collections.Generic;
using UnityEngine;

public class PlaceablesScriptableObjects : MonoBehaviour
{
    public static PlaceablesScriptableObjects Instance { get; private set; }

    private Dictionary<string, GameObject> placeablePrefabs;

    public IReadOnlyDictionary<string, GameObject> PlaceablePrefabs => placeablePrefabs;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        placeablePrefabs = new Dictionary<string, GameObject>();

        foreach (GameObject prefab in Resources.LoadAll<GameObject>("Placeables"))
        {
            placeablePrefabs[prefab.name] = prefab;
        }
    }
}