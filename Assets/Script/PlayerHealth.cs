using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;  // プレイヤーの最大HP
    private int currentHP;    // プレイヤーの現在のHP
    public Slider healthBar;  // UIのスライダー
    public Image fillImage;   // スライダーのフィル部分 (色を変えるためのImage)

    // 色の変化 (緑から赤)
    public Color highHPColor = Color.green;
    public Color lowHPColor = Color.red;

    void Start()
    {
        currentHP = maxHP; // 最初はHPを最大にする
        healthBar.maxValue = maxHP; // スライダーの最大値を設定
        healthBar.value = currentHP; // 現在のHPをスライダーに反映
        UpdateHealthBarColor(); // 初期色を設定
    }

    // ダメージを受けるメソッド
    public void TakeDamage(int damage)
    {
        currentHP -= damage; // HPを減らす
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // HPが0以下にならないように制限
        healthBar.value = currentHP; // スライダーの値を更新
        UpdateHealthBarColor(); // 色を更新

        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die(); // HPが0になったら死亡処理
        }
    }

    // プレイヤーが死亡したときの処理
    private void Die()
    {
        Debug.Log("Player defeated!");
        // ゲームオーバー処理を追加することができます
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    // HPに応じて体力バーの色を更新する
    private void UpdateHealthBarColor()
    {
        // HPの割合を計算 (0.0 ～ 1.0)
        float healthPercentage = (float)currentHP / maxHP;

        // 緑から赤に色を補間して設定
        fillImage.color = Color.Lerp(lowHPColor, highHPColor, healthPercentage);
    }

    // HPを回復するメソッド (オプション)
    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // HPが最大を超えないように制限
        healthBar.value = currentHP; // スライダーの値を更新
        UpdateHealthBarColor(); // 色を更新
    }
}