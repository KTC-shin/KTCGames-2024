using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // �V���O���g���p�^�[�����g�p

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �{�X���|���ꂽ���̃Q�[���N���A����
    public void CheckForVictory()
    {
        // �{�X��|�����ꍇ�̏���
        Debug.Log("Game Clear!");
        // �Q�[���N���A��ʂ�\��������A�V�[����؂�ւ��鏈����ǉ�
        // �Ⴆ�΁A�V�[���̐؂�ւ�:
        // SceneManager.LoadScene("VictoryScene");
    }
}
