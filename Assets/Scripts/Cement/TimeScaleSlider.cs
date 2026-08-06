using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleSlider : MonoBehaviour
{
    public void UpdateTimeScaleSlider(float value)
    {
        TimeManager.Instance.SetTimeScale(value);
    }
}
