using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlaceableData : ScriptableObject
{
    public GameObject prefab;
    public GameObject prefabGhost;
    public Sprite icon;

    public List<string> changeableproperties;
}
