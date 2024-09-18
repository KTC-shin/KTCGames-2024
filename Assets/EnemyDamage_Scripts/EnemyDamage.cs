using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 10;  // �{�X�ɗ^����_���[�W��

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g���{�X���ǂ������`�F�b�N
        if (collision.gameObject.CompareTag("Boss"))
        {
            BossEnemy boss = collision.gameObject.GetComponent<BossEnemy>();
            if (boss != null)
            {
                boss.TakeDamage(damageAmount);  // �{�X�Ƀ_���[�W��^����
            }
        }
    }
}
