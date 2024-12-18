using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using Unity.Mathematics;
using UnityEditor.UIElements;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float       cooldown;
    [SerializeField] private float       speed          = 5;
    [SerializeField] private float       jumpForce      = 20;
    [SerializeField] private float       deltaTimeShoot = 0.5f;
    [SerializeField] private float       limitUp        = 1;
    [SerializeField] private float       limitDown      = 1;
    [SerializeField] private BulletType  bulletType;
    [SerializeField] private int         bulletLevel;

    private void Awake() {
        GetComponent<Animator>().Play(GetComponent<Animator>().runtimeAnimatorController.animationClips[GameData.Instance.AnimId].name);
    }

    // Start is called before the first frame update
    void Start() {
        cooldown = deltaTimeShoot;
    }
    
    // Update is called once per frame
    void Update() {
        if (transform.position.y < -Camera.main.orthographicSize - limitDown)
            transform.position = new Vector2(transform.position.x, -Camera.main.orthographicSize - limitDown); 
        if (transform.position.y > Camera.main.orthographicSize + limitUp)
            transform.position = new Vector2(transform.position.x, Camera.main.orthographicSize + limitUp);
        if (Input.GetMouseButtonDown(0)) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            AudioManager.Instance.Shot(eSoundName.Jump);
        }

        ShootingHandle();
    }

    void ShootingHandle() {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0) {
            AudioManager.Instance.Shot(eSoundName.Shoot);
            cooldown = deltaTimeShoot;
            Bullet bullet = (Bullet)PoolingManager.Instance.GetObject(NamePrefabPool.Bullet, null, transform.position);
            bullet.Disable(2f);
            bullet.SetData(BulletType.Red, 1);
        }
    }
}
