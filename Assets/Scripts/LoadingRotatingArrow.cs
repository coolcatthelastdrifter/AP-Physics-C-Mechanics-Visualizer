using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingRotatingArrow : MonoBehaviour
{
    public LevelLoader LevelLoader;
    public Vector3 rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (0 < LevelLoader.loadProgress && LevelLoader.loadProgress< 1)
        {
            transform.rotation *= Quaternion.Euler(rotationSpeed * Time.deltaTime);
        }
    }
}
