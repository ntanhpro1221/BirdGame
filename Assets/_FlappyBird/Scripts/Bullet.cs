using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class Bullet : BasePooling {
	[SerializeField] private float          speed;
	[SerializeField] private Rigidbody2D    rb;
	[SerializeField] private SpriteRenderer sr;
	public                   float          atk;
	public                   BulletType     bulletType;
	public                   int            bulletLevel;
	
	private void OnEnable() {
		rb.velocity = new Vector2(speed, 0);	
	}
	
	public void SetData(BulletType bulletType, int bulletLevel) {
		this.bulletType                       = bulletType;
		this.bulletLevel                      = bulletLevel;
		GetComponent<SpriteRenderer>().sprite = GameData.Instance.bulletData.listBulletSprite[(int)bulletType].listInfo[bulletLevel].sprite;
		atk = GameData.Instance.bulletData.listBulletSprite[(int)bulletType].listInfo[bulletLevel].atk;
	}
}
