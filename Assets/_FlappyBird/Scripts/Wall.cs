using System;
using GameTool;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Wall : BasePooling {
	private int[]   height = new int[4];
	private float[] posY    = new float[4];
	private float   sizeUnit;
	
	private void OnEnable() { 
		sizeUnit = Camera.main.orthographicSize;
		BuildWall();
	}

	private void BuildWall() {
		height[0] = Random.Range(1, 4);
		height[1] = 5 - height[0];
		height[2] = Random.Range(1, 4);
		height[3] = 5 - height[2];

		posY[0] = 5 - height[0] / 2f;
		posY[1] = height[1] / 2f;
		posY[2] = -height[2] / 2f;
		posY[3] = height[3] / 2f - 5;

		for (var i = 0; i < 4; ++i) {
			Block block = (Block)PoolingManager.Instance.GetObject(
				NamePrefabPool.Block,
				transform,
				new Vector3(transform.position.x, posY[i]));
			block.GetComponent<SpriteRenderer>().size = new Vector2(1, height[i]);
			block.GetComponent<BoxCollider2D>().size  = new Vector2(1, height[i]);
			block.SetData((BlockType)Random.Range(0, 3));
		}
	}
}
