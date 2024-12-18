using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Test : MonoBehaviour {
	[SerializeField] private Animator animator;
	
	public void NextAnim() {
		foreach (AnimatorClipInfo lmao in animator.GetCurrentAnimatorClipInfo(0)) {
			Debug.Log(lmao.clip.name);	
		}
	}
}
