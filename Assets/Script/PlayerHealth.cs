using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // 最大HP
    public int currentHealth;   // 現在のHP

    void Start()
    {
        currentHealth = maxHealth; // ゲーム開始時にHPを最大に設定
    }

    // ダメージを受けたときに呼び出す関数
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ダメージ分HPを減少

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // HPが0以下になったら死亡
        }
    }

    // プレイヤーが死亡したときの処理
    void Die()
    {
        Debug.Log("Player is dead!");
        // 死亡時の処理をここに追加（例：リトライ画面を表示するなど）
    }
}