using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossEnemy : MonoBehaviour
{
    public int maxHP = 100;  // �{�X�̍ő�HP
    public int currentHP;    // �{�X�̌��݂�HP
    public Slider healthBar; // �̗̓o�[ (UI�̃X���C�_�[)
    public Image fillImage;  // �X���C�_�[�̃t�B������ (�F��ς��邽�߂�Image)

    // �F�̕ω� (�΂����)
    public Color highHPColor = Color.green;
    public Color lowHPColor = Color.red;

    void Start()
    {
        currentHP = maxHP; // �ŏ���HP���ő�ɂ���
        healthBar.maxValue = maxHP; // �X���C�_�[�̍ő�l���{�X��HP�ɐݒ�
        healthBar.value = currentHP; // ���݂�HP�ɉ����ăX���C�_�[�̒l��ݒ�
        UpdateHealthBarColor(); // �����F��ݒ�
    }

    // �{�X���_���[�W���󂯂�Ƃ��̃��\�b�h
    public void TakeDamage(int damage)
    {
        currentHP -= damage;  // �_���[�W���󂯂�HP�����炷
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);  // HP��0�ȉ��ɂȂ�Ȃ��悤�ɐ���
        healthBar.value = currentHP;  // �̗̓o�[���X�V
        UpdateHealthBarColor(); // �F���X�V
        Debug.Log("Boss HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    // HP�ɉ����đ̗̓o�[�̐F���X�V����
    private void UpdateHealthBarColor()
    {
        // HP�̊������v�Z (0.0 �` 1.0)
        float healthPercentage = (float)currentHP / maxHP;

        // �΂���ԂɐF���Ԃ��Đݒ�
        fillImage.color = Color.Lerp(lowHPColor, highHPColor, healthPercentage);
    }

    // �{�X�����񂾂Ƃ��̏���
    private void Die()
    {
        Debug.Log("Boss defeated!");

        SceneManager.LoadScene("ClearScene", LoadSceneMode.Single);

        // �Q�[���N���A������Ăяo��
        GameManager.Instance.CheckForVictory();

        Destroy(gameObject);  // �{�X�����񂾂�I�u�W�F�N�g��j�󂷂�
    }
}
