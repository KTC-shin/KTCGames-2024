using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Beem_disappear : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // 壁やプレイヤーに当たったらビームを破壊
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
