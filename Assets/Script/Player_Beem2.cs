using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Beem2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // エネミーにビームが当たったかどうかを確認
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // エネミーのビーム発射スクリプトを取得してビームを止める
            EnemyShootingControl enemyShooting = collision.gameObject.GetComponent<EnemyShootingControl>();
            if (enemyShooting != null)
            {
                enemyShooting.StopShooting();
            }

            // プレイヤーのビームを破壊
            Destroy(gameObject);
        }
    }
}
