using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingControl : MonoBehaviour
{
    public GameObject enemyBeamPrefab;   // エネミーのビームPrefab
    public Transform firePoint;          // 発射位置
    public float fireRate = 1f;          // 発射間隔
    public float beamSpeed = 10f;        // ビームの速度
    private Transform player;            // プレイヤーのTransform
    private bool canShoot = true;        // ビームが発射可能か

    private void Start()
    {
        // プレイヤーをTagで検索
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // 一定間隔でビームを発射する
        InvokeRepeating("ShootAtPlayer", fireRate, fireRate);
    }

    void ShootAtPlayer()
    {
        if (player != null && canShoot)
        {
            // プレイヤーへの方向を計算
            Vector3 direction = (player.position - firePoint.position).normalized;

            // ビームを生成
            GameObject beam = Instantiate(enemyBeamPrefab, firePoint.position, Quaternion.LookRotation(direction));

            // ビームの Rigidbody コンポーネントを取得して方向に応じた力を加える
            Rigidbody rb = beam.GetComponent<Rigidbody>();
            rb.velocity = direction * beamSpeed;
        }
    }

    // プレイヤーのビームがエネミーに当たった場合にビーム発射を停止する
    public void StopShooting()
    {
        canShoot = false;  // ビームを止める
    }

    // エネミーがプレイヤーのビームに当たった時の処理
    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーのビームに当たったかどうかを確認（PlayerBeamというタグがついている前提）
        if (other.CompareTag("Laser"))
        {
            StopShooting();  // ビーム発射を停止する
        }
    }
}

