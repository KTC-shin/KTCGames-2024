using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Force : MonoBehaviour
{
    public float pushForce = 10f;  // エネミーに加える力の大きさ

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))  // エネミーと衝突したかを確認
        {
            Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                // レーザーの方向に基づいて力を加える
                Vector3 forceDirection = other.transform.position - transform.position;
                forceDirection.Normalize();
                enemyRigidbody.AddForce(forceDirection * pushForce, ForceMode.Impulse);
            }

            // レーザーを削除
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall")) // 壁に当たった場合の処理
        {
            Destroy(gameObject);
        }
    }
}
