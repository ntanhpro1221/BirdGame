using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour {
    public RectTransform BGBar;

    public RectTransform ProgressBar;

    public TextMeshProUGUI ProgressText;

    public AsyncOperation loadSceneAsync;
    
    void Start() {
        StartCoroutine(LoadSceneAsync());
    }
    
    public IEnumerator LoadSceneAsync() {
        loadSceneAsync                      = SceneManager.LoadSceneAsync("LobbyScene");
        while (!loadSceneAsync.isDone) {
            ProgressText.text     = ((int)(loadSceneAsync.progress * 100)).ToString() + '%';
            ProgressBar.sizeDelta = new Vector2(BGBar.sizeDelta.x * loadSceneAsync.progress, ProgressBar.sizeDelta.y);
            yield return null;
        }
    }
}
