using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour {
	public  Animator        animator;
	private AnimationClip[] animClip;

	private void Awake() {
		animClip = animator.runtimeAnimatorController.animationClips;
		animator.Play(animClip[GameData.Instance.AnimId].name);
		AudioManager.Instance.PlayMusic(eMusicName.Lobby);
	}

	public void Play() {
		LoadSceneManager.Instance.LoadScene("InGameScene");
	}

	public void NextAnim() {
		GameData.Instance.AnimId = (GameData.Instance.AnimId + 1) % animClip.Length;
		animator.Play(animClip[GameData.Instance.AnimId].name);
	}

	public void PrevAnim() {
		GameData.Instance.AnimId = (GameData.Instance.AnimId - 1 + animClip.Length) % animClip.Length;
		animator.Play(animClip[GameData.Instance.AnimId].name);
	}
}
