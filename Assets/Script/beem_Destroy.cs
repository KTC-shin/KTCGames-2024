using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beem_Destroy : MonoBehaviour
{
    // �ՓˑΏۂ̃^�O��ݒ肷�邽�߂̕ϐ�
    public string[] targets; // ����������ƂȂ�^�[�Q�b�g�^�O







    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O�� targets �Ɋ܂܂�Ă��邩�`�F�b�N
        foreach (string target in targets)
        {
            if (collision.collider.CompareTag(target))
            {
                // �I�u�W�F�N�g��j�󂷂�
                Destroy(gameObject);
                break;
            }
        }
    }
}
