using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class Block : BasePooling {
	private float     speed = 6;
	private float     curHP;
	private float     maxHP;
	private BlockType blockType;
	
	private void OnEnable() {
		speed                                = GameData.Instance.moveSpeed;
		GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
	}
	private void SetSprite(int id) {
		GetComponent<SpriteRenderer>().sprite = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.listSprite[id];
	}
	
	private void TakeDamage(Bullet bullet) {
		AudioManager.Instance.Shot((eSoundName)Enum.Parse(typeof(eSoundName), blockType.ToString()));
		curHP -= bullet.atk;
		if (curHP / maxHP <= 0f / 3) {
			GameMenu.Instance.UpdateScore(1);
			Destroy(gameObject);
		}
		else for (float i = 1; i <= 3f; i += 1) if (curHP / maxHP <= i / 3) {
			SetSprite((int)i - 1);
			break;
		}
	}
	private void OnTriggerEnter2D(Collider2D other) {
		Console.WriteLine(other.gameObject.tag);
		if (other.gameObject.CompareTag("Bullet")) {
			TakeDamage(other.gameObject.GetComponent<Bullet>());
			Destroy(other.gameObject);
		}

		if (other.gameObject.CompareTag("Player")) {
			GameMenu.Instance.ShowDeadPopup();
			Time.timeScale = 0;
		}
	}
	public void SetData(BlockType _blockType) {
		blockType = _blockType;
		curHP     = maxHP = GameData.Instance.blockData.listBlockSprite[(int)blockType].spriteInfos.maxHP;
		SetSprite(2);
	}
}
