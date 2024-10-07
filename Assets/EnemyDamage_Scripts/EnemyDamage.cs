using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;  // ボスに与えるダメージ量

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがボスかどうかをチェック
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossEnemy boss = collision.gameObject.GetComponent<BossEnemy>();
            if (boss != null)
            {
                boss.TakeDamage(damageAmount);  // ボスにダメージを与える
            }
        }
    }
}
