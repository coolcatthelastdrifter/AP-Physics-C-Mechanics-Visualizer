using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNotActiveOnFinishedLoading : MonoBehaviour
{
    public LevelLoader LevelLoader;

    private void Awake()
    {
        LevelLoader.finishedLoading += () => gameObject.SetActive(false);
    }
}
