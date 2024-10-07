using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Beem2 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // �G�l�~�[�Ƀr�[���������������ǂ������m�F
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // �G�l�~�[�̃r�[�����˃X�N���v�g���擾���ăr�[�����~�߂�
            EnemyShootingControl enemyShooting = collision.gameObject.GetComponent<EnemyShootingControl>();
            if (enemyShooting != null)
            {
                enemyShooting.StopShooting();
            }

            // �v���C���[�̃r�[����j��
            Destroy(gameObject);
        }
    }
}
