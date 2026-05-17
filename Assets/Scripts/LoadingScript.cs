using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider loadingSlider;
    public TextMeshProUGUI progressText;

    public void LoadLevel (int sceneIndex)
    {
        loadingScreen.SetActive (true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        while (!operation.isDone)
        {
            float progress = operation.progress;
            
            loadingSlider.value = progress;
            progressText.text =  progress *100f + "%";

            Debug.Log(progress);

            yield return null;
        }
    }
}
