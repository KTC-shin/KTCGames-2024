using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beem_Damage : MonoBehaviour
{
    public int damage = 10;  // ビームが与えるダメージ

    void OnTriggerEnter(Collider other)
    {
        // プレイヤーに当たった場合
        if (other.CompareTag("Player"))
        {
            // プレイヤーのPlayerHealthスクリプトを取得
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // プレイヤーにダメージを与える
                playerHealth.TakeDamage(damage);
            }

            // ビームを消す（必要に応じて）
            Destroy(gameObject);
        }
    }
}
