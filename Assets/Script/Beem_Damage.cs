using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beem_Damage : MonoBehaviour
{
    public int damage = 10;  // ビームが与えるダメージ

    private void OnCollisionEnter(Collision collision)
    {
        // プレイヤーに当たった場合
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーのPlayerHealthスクリプトを取得
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                Debug.Log("aaa");
                // プレイヤーにダメージを与える
                playerHealth.TakeDamage(damage);
            }

            // ビームを消す（必要に応じて）
            Destroy(gameObject);
        }
    }
}
