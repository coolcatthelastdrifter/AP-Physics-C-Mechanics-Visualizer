using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaceablePropertyFunction : ScriptableObject
{
    public abstract void Apply(GameObject placeable, string value);
}
