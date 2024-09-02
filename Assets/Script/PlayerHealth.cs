using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // �ő�HP
    public int currentHealth;   // ���݂�HP

    void Start()
    {
        currentHealth = maxHealth; // �Q�[���J�n����HP���ő�ɐݒ�
    }

    // �_���[�W���󂯂��Ƃ��ɌĂяo���֐�
    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // �_���[�W��HP������

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // HP��0�ȉ��ɂȂ����玀�S
        }
    }

    // �v���C���[�����S�����Ƃ��̏���
    void Die()
    {
        Debug.Log("Player is dead!");
        // ���S���̏����������ɒǉ��i��F���g���C��ʂ�\������Ȃǁj
    }
}