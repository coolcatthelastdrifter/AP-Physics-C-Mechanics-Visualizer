using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneOnStart : MonoBehaviour
{
    public int sceneIndexToLoad;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<LoadingScript>().LoadLevel(sceneIndexToLoad);
    }
}
