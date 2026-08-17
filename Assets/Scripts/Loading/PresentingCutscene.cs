using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadedHandler : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene finished loading: " + scene.name);

        // Run your setup code here
    }
}