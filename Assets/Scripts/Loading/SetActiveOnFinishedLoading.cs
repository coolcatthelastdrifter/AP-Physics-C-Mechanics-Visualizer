using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveOnFinishedLoading : MonoBehaviour
{
    public LevelLoader LevelLoader;
    public GameObject objectToSetActive;

    private void Awake()
    {
        LevelLoader.finishedLoading += () => objectToSetActive.SetActive(true);
    }
}
