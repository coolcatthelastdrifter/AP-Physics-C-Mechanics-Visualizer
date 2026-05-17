using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LoadingScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public UnityEngine.UI.Slider loadingSlider;
    public TextMeshProUGUI progressText;

    // How long the loading screen should stay visible at minimum
    public float minimumLoadTime = 1f;

    // How quickly the UI catches up
    public float smoothSpeed = 3f;

    public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        float timer = 0f;
        float displayedProgress = 0f;

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        // Prevent scene from activating immediately
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            timer += Time.deltaTime;

            // Real loading progress (0 -> 1)
            float targetProgress = Mathf.Clamp01(operation.progress / 0.9f);

            // Smoothly animate UI
            displayedProgress = Mathf.MoveTowards(
                displayedProgress,
                targetProgress,
                smoothSpeed * Time.deltaTime
            );

            loadingSlider.value = displayedProgress;
            progressText.text = Mathf.RoundToInt(displayedProgress * 100f) + "%";

            // When fully loaded AND minimum time passed
            if (targetProgress >= 1f && timer >= minimumLoadTime)
            {
                // Optional: fill bar completely first
                loadingSlider.value = 1f;
                progressText.text = "100%";

                yield return new WaitForSeconds(0.25f);

                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}