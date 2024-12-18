using System.Collections;
using System.Collections.Generic;
using GameTool;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class GameMenu : SingletonUI<GameMenu> {
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI highScoreText;
	public GameObject      deadPopup;

	private void Start() {
		// Debug.Log(GameData.Instance.HighScore);
		highScoreText.text      = "High Score: " + GameData.Instance.HighScore;
		GameData.Instance.score = 0;
		scoreText.text          = "Score: 0";
	}
	
	public void UpdateScore(int amount) {
		GameData.Instance.score     += amount;
		GameData.Instance.HighScore =  math.max(GameData.Instance.HighScore, GameData.Instance.score);
		scoreText.text              =  "Score: " + GameData.Instance.score;
		highScoreText.text          =  "High Score: " + GameData.Instance.HighScore;
	}

	public void ShowDeadPopup() {
		Instantiate(deadPopup, transform);
	}
}
