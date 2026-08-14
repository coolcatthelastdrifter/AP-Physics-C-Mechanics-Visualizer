using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Placeable Properties/Mass")]
public class MassProperty : PlaceablePropertyFunction
{
    public override void Apply(GameObject placeable, string value)
    {
        placeable.GetComponent<Rigidbody>().mass = int.Parse(value);
    }
}