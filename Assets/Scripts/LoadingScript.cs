using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingArrow;
    public TextMeshProUGUI progressText;

    public Button continueButton;

    public float rotationSpeed = 180f;

    private bool isLoading = false;
    private bool readyToContinue = false;

    private AsyncOperation currentOperation;

    public void LoadLevel(int sceneIndex)
    {
        loadingScreen.SetActive(true);

        continueButton.gameObject.SetActive(false);

        loadingArrow.rectTransform.rotation = Quaternion.identity;

        isLoading = true;

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    private void Update()
    {
        if (isLoading)
        {
            loadingArrow.rectTransform.Rotate(
                0f,
                0f,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        float timer = 0f;

        currentOperation = SceneManager.LoadSceneAsync(sceneIndex);
        currentOperation.allowSceneActivation = false;

        while (!currentOperation.isDone)
        {
            timer += Time.deltaTime;

            float progress =
                Mathf.Clamp01(currentOperation.progress / 0.9f);

            progressText.text =
                Mathf.RoundToInt(progress * 100f) + "%";

            if (progress >= 1f)
            {
                loadingArrow.gameObject.SetActive(false);
                isLoading = false;

                progressText.text = "Press Continue";

                continueButton.gameObject.SetActive(true);

                readyToContinue = true;

                yield break;
            }

            yield return null;
        }
    }

    public void ContinueToScene()
    {
        if (readyToContinue)
        {
            currentOperation.allowSceneActivation = true;
        }
    }
}