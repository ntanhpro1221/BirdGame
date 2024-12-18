using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GameTool;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadPopup : MonoBehaviour
{
	public void Exit() {
		LoadSceneManager.Instance.LoadScene("LobbyScene");
        PoolingManager.Instance.DisableAllObject();
	}

	public void PlayAgain() {
		LoadSceneManager.Instance.LoadScene("InGameScene");
        PoolingManager.Instance.DisableAllObject();
	}
}
