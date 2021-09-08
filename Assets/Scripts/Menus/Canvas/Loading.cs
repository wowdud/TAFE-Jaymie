using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    public GameObject loadingScreen;
    public Image loadingBar;
    public Text loadingText;

    IEnumerator Load(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progress;
            loadingText.text = progress * 100 + "%";
            yield return null;
        }
    }
    public void LoadingLevel(int sceneIndex)
    {
        StartCoroutine(Load(sceneIndex));
    }
}
