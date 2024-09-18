using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Beem_disappear : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // プレイヤーに衝突したかを確認
        if (collision.gameObject.CompareTag("Player"))
        {
            // ビームを消す
            Destroy(gameObject);
        }
    }

    // OnTriggerEnterを使用したい場合はこちら
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    */
}
