using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Force : MonoBehaviour
{
    public float pushForce = 10f;  // �G�l�~�[�ɉ�����͂̑傫��

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))  // �G�l�~�[�ƏՓ˂��������m�F
        {
            Rigidbody enemyRigidbody = other.GetComponent<Rigidbody>();
            if (enemyRigidbody != null)
            {
                // ���[�U�[�̕����Ɋ�Â��ė͂�������
                Vector3 forceDirection = other.transform.position - transform.position;
                forceDirection.Normalize();
                enemyRigidbody.AddForce(forceDirection * pushForce, ForceMode.Impulse);
            }

            // ���[�U�[���폜
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall")) // �ǂɓ��������ꍇ�̏���
        {
            Destroy(gameObject);
        }
    }
}
