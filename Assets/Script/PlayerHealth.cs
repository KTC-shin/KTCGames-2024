using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;  // �v���C���[�̍ő�HP
    private int currentHP;    // �v���C���[�̌��݂�HP
    public Slider healthBar;  // UI�̃X���C�_�[
    public Image fillImage;   // �X���C�_�[�̃t�B������ (�F��ς��邽�߂�Image)

    // �F�̕ω� (�΂����)
    public Color highHPColor = Color.green;
    public Color lowHPColor = Color.red;

    void Start()
    {
        currentHP = maxHP; // �ŏ���HP���ő�ɂ���
        healthBar.maxValue = maxHP; // �X���C�_�[�̍ő�l��ݒ�
        healthBar.value = currentHP; // ���݂�HP���X���C�_�[�ɔ��f
        UpdateHealthBarColor(); // �����F��ݒ�
    }

    // �_���[�W���󂯂郁�\�b�h
    public void TakeDamage(int damage)
    {
        currentHP -= damage; // HP�����炷
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // HP��0�ȉ��ɂȂ�Ȃ��悤�ɐ���
        healthBar.value = currentHP; // �X���C�_�[�̒l���X�V
        UpdateHealthBarColor(); // �F���X�V

        Debug.Log("Player HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die(); // HP��0�ɂȂ����玀�S����
        }
    }

    // �v���C���[�����S�����Ƃ��̏���
    private void Die()
    {
        Debug.Log("Player defeated!");
        // �Q�[���I�[�o�[������ǉ����邱�Ƃ��ł��܂�
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }

    // HP�ɉ����đ̗̓o�[�̐F���X�V����
    private void UpdateHealthBarColor()
    {
        // HP�̊������v�Z (0.0 �` 1.0)
        float healthPercentage = (float)currentHP / maxHP;

        // �΂���ԂɐF���Ԃ��Đݒ�
        fillImage.color = Color.Lerp(lowHPColor, highHPColor, healthPercentage);
    }

    // HP���񕜂��郁�\�b�h (�I�v�V����)
    public void Heal(int amount)
    {
        currentHP += amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP); // HP���ő�𒴂��Ȃ��悤�ɐ���
        healthBar.value = currentHP; // �X���C�_�[�̒l���X�V
        UpdateHealthBarColor(); // �F���X�V
    }
}