using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Moov : MonoBehaviour
{
    public float moveSpeed = 5f; // �G�l�~�[�̈ړ����x
    private Transform playerTransform; // �v���C���[��Transform

    void Start()
    {
        // �v���C���[�I�u�W�F�N�g��"Player"�^�O�Ō�������Transform���擾
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogWarning("Player object not found. Make sure the player has the 'Player' tag.");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            // �v���C���[�̍��W���擾
            Vector3 playerPosition = playerTransform.position;

            // �G�l�~�[���v���C���[�̕���������
            transform.LookAt(playerPosition);

            // �G�l�~�[���v���C���[�̈ʒu�Ɍ������Ĉړ�
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, moveSpeed * Time.deltaTime);
        }
    }
    //public Transform player; // �v���C���[��Transform
    //public float speed = 5f;  // �G�̈ړ����x



    //void Update()
    //{

    //    // �v���C���[�ƓG�̈ʒu���r���ĕ������v�Z
    //    Vector3 direction = player.position - transform.position;
    //    direction.Normalize(); // ������1�ɐ��K��

    //    // �G���v���C���[�Ɍ������Ĉړ�
    //    transform.position += direction * speed * Time.deltaTime;

    //    // �G�̌������v���C���[�̕����Ɍ�����
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    //}
}