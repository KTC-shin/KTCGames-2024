using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    public int maxHP = 100;  // ボスの最大HP
    public int currentHP;    // ボスの現在のHP
    public Slider healthBar; // 体力バー (UIのスライダー)
    public Image fillImage;  // スライダーのフィル部分 (色を変えるためのImage)

    // 色の変化 (緑から赤)
    public Color highHPColor = Color.green;
    public Color lowHPColor = Color.red;

    void Start()
    {
        currentHP = maxHP; // 最初はHPを最大にする
        healthBar.maxValue = maxHP; // スライダーの最大値をボスのHPに設定
        healthBar.value = currentHP; // 現在のHPに応じてスライダーの値を設定
        UpdateHealthBarColor(); // 初期色を設定
    }

    // ボスがダメージを受けるときのメソッド
    public void TakeDamage(int damage)
    {
        currentHP -= damage;  // ダメージを受けてHPを減らす
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);  // HPが0以下にならないように制限
        healthBar.value = currentHP;  // 体力バーを更新
        UpdateHealthBarColor(); // 色を更新
        Debug.Log("Boss HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    // HPに応じて体力バーの色を更新する
    private void UpdateHealthBarColor()
    {
        // HPの割合を計算 (0.0 ～ 1.0)
        float healthPercentage = (float)currentHP / maxHP;

        // 緑から赤に色を補間して設定
        fillImage.color = Color.Lerp(lowHPColor, highHPColor, healthPercentage);
    }

    // ボスが死んだときの処理
    private void Die()
    {
        Debug.Log("Boss defeated!");

        SceneManager.LoadScene("ClearScene", LoadSceneMode.Single);

        // ゲームクリア判定を呼び出す
        GameManager.Instance.CheckForVictory();

        Destroy(gameObject);  // ボスが死んだらオブジェクトを破壊する
    }
}
