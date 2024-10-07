using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Moov : MonoBehaviour
{
    public float moveSpeed = 5f; // エネミーの移動速度
    private Transform playerTransform; // プレイヤーのTransform

    void Start()
    {
        // プレイヤーオブジェクトを"Player"タグで検索してTransformを取得
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found. Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // プレイヤーの座標を取得
            Vector3 playerPosition = playerTransform.position;

            // エネミーがプレイヤーの方向を向く
            transform.LookAt(playerPosition);

            // エネミーがプレイヤーの位置に向かって移動
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
        }
    }
    //public Transform player; // プレイヤーのTransform
    //public float speed = 5f;  // 敵の移動速度



    //void Update()
    //{

    //    // プレイヤーと敵の位置を比較して方向を計算
    //    Vector3 direction = player.position - transform.position;
    //    direction.Normalize(); // 距離を1に正規化

    //    // 敵をプレイヤーに向かって移動
    //    transform.position += direction * speed * Time.deltaTime;

    //    // 敵の向きをプレイヤーの方向に向ける
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //}
}