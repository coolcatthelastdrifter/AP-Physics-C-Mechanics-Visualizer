using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnStart : MonoBehaviour
{
    public int sceneIndexToLoad;
    public bool manualContinue;
    public LevelLoader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        levelLoader.LoadLevel(sceneIndexToLoad, manualContinue);
    }
}
