using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject beamPrefab;  // ビームのプレハブ
    public Transform firePoint;    // ビームを発射する位置
    public float fireRate = 1.0f;  // 発射間隔
    public float beamSpeed = 10f;  // ビームの速度
    private Transform player;      // プレイヤーの位置
    private float nextFireTime;    // 次に発射できる時間
    private bool canShoot = true;  // エネミーがビームを発射できるかを管理するフラグ

    void Start()
    {
        // プレイヤーを見つける
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // 発射可能で、次の発射時間を超えた場合にビームを撃つ
        if (canShoot && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        // ビームのインスタンスを生成
        GameObject beam = Instantiate(beamPrefab, firePoint.position, firePoint.rotation);

        // プレイヤーの位置に向かってビームを飛ばす
        Vector3 direction = (player.position - firePoint.position).normalized;

        // Rigidbodyを使ってビームに力を加える
        Rigidbody rb = beam.GetComponent<Rigidbody>();
        rb.velocity = direction * beamSpeed;
    }

    // プレイヤーのレーザーに当たったときに発射を停止するメソッド
    public void StopShooting()
    {
        canShoot = false;
    }
}

