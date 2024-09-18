using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beem_Damage : MonoBehaviour
{
    public int damage = 10;  // �r�[�����^����_���[�W

    void OnTriggerEnter(Collider other)
    {
        // �v���C���[�ɓ��������ꍇ
        if (other.CompareTag("Player"))
        {
            // �v���C���[��PlayerHealth�X�N���v�g���擾
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                // �v���C���[�Ƀ_���[�W��^����
                playerHealth.TakeDamage(damage);
            }

            // �r�[���������i�K�v�ɉ����āj
            Destroy(gameObject);
        }
    }
}
