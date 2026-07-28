using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableProperty : MonoBehaviour
{
    public float FloatValue;
    public bool BoolValue;
    public string StringValue;

    public enum OptionType
    {
        Float,
        Bool,
        String
    }

    public OptionType Type;

    public PlaceableProperty(float value)
    {
        FloatValue = value;
        BoolValue = false;
        StringValue = null;
        Type = OptionType.Float;
    }

    public PlaceableProperty(bool value)
    {
        FloatValue = 0f;
        BoolValue = value;
        StringValue = null;
        Type = OptionType.Bool;
    }

    public PlaceableProperty(string value)
    {
        FloatValue = 0f;
        BoolValue = false;
        StringValue = value;
        Type = OptionType.String;
    }
}
