using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static            GameManager Instance { get; set; }
    [SerializeField] private float       wallCooldown    = 4;
    [SerializeField] private float       curWallCooldown = 4;
    [SerializeField] private GameObject  background;

    private float moveSpeed;
    
    // Start is called before the first frame update
    void Awake() {
        moveSpeed = GameData.Instance.moveSpeed;
        AudioManager.Instance.PlayMusic(eMusicName.Battle);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
	    curWallCooldown -= Time.deltaTime;
        if (curWallCooldown <= 0) {
            curWallCooldown = wallCooldown;
            PoolingManager.Instance.GetObject(NamePrefabPool.Wall, null, new Vector3(Camera.main.orthographicSize * 2, 0)).Disable(10f);
        }

        UpdateBackground();
    }

    void UpdateBackground() {
        float pos         = background.transform.position.x;
        background.transform.position = new Vector3(pos - moveSpeed * Time.deltaTime, 0);
        float widthBG     = background.GetComponent<SpriteRenderer>().bounds.size.x;
        float widthScreen = Camera.main.orthographicSize * Screen.width / Screen.height;
        if (pos + widthBG / 2 <= widthScreen) {
            background.transform.position =  new Vector3(pos + widthBG / 2, 0);
        }
    }
}
