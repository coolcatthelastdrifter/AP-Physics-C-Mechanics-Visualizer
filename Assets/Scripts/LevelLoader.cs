using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private bool readyToContinue = false;

    private AsyncOperation currentOperation;
    public float loadProgress;

    public Animator transition;

    public float transitionTime = 1f;

    public event System.Action finishedLoading;

    public void LoadLevel(int levelIndex, bool manualContinue)
    {
        StartCoroutine(LoadAsynchronously(levelIndex, manualContinue));
    }

    IEnumerator LoadAsynchronously(int sceneIndex, bool manualContinue)
    {
        Debug.Log("LOADING");
        float timer = 0f;

        currentOperation = SceneManager.LoadSceneAsync(sceneIndex);
        currentOperation.allowSceneActivation = false;

        while (!currentOperation.isDone)
        {
            timer += Time.deltaTime;

            loadProgress =
                Mathf.Clamp01(currentOperation.progress / 0.9f);

            if (loadProgress >= 1f)
            {
                Debug.Log("Ready");
                readyToContinue = true;
                finishedLoading?.Invoke();

                currentOperation.allowSceneActivation = !manualContinue;

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
