using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Beem_disappear : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        // �v���C���[�ɏՓ˂��������m�F
        if (collision.gameObject.CompareTag("Player"))
        {
            // �r�[��������
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter���g�p�������ꍇ�͂�����
    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    */
}
