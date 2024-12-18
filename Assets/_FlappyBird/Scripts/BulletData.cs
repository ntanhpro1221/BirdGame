using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet Data", menuName = "Data/Bullet Data")]
public class BulletData : ScriptableObject {
	public List<BulletSprite> listBulletSprite;
}

[Serializable]
public class BulletSprite {
	public BulletType        bulletType;
	public List<BulletInfos> listInfo;
}

[Serializable]
public class BulletInfos {
	public Sprite sprite;
	public float  atk;
}

public enum BulletType {
	Red = 0,
	Green = 1,
	Blue = 2,
}