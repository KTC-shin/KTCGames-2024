using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage = 10;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }


        //参考コード↓
        //if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth pHealth))
        //{
        //    pHealth.TakeDamage(damage);
        //}

        //if (collision.gameObject.TryGetComponent<BossEnemy>(out BossEnemy boss))
        //{
        //    Destroy(gameObject);
        //}
    }
}
    
    //ToDo : やりたいこと
    //Fix : 修正内容