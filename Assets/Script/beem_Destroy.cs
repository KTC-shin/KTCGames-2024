using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beem_Destroy : MonoBehaviour
{
    // 衝突対象のタグを設定するための変数
    public string[] targets; // 消える条件となるターゲットタグ







    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトのタグが targets に含まれているかチェック
        foreach (string target in targets)
        {
            if (collision.collider.CompareTag(target))
            {
                // オブジェクトを破壊する
                Destroy(gameObject);
                break;
            }
        }
    }
}
