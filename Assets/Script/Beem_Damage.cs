using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beem_Damage : MonoBehaviour
{
    public int damage = 10;  // �r�[�����^����_���[�W

    private void OnCollisionEnter(Collision collision)
    {
        // �v���C���[�ɓ��������ꍇ
        if (collision.gameObject.CompareTag("Player"))
        {
            // �v���C���[��PlayerHealth�X�N���v�g���擾
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                Debug.Log("aaa");
                // �v���C���[�Ƀ_���[�W��^����
                playerHealth.TakeDamage(damage);
            }

            // �r�[���������i�K�v�ɉ����āj
            Destroy(gameObject);
        }
    }
}
