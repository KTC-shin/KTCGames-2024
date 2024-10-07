using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;  // シングルトンパターンを使用

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

    // ボスが倒された時のゲームクリア処理
    public void CheckForVictory()
    {
        // ボスを倒した場合の処理
        Debug.Log("Game Clear!");
        // ゲームクリア画面を表示したり、シーンを切り替える処理を追加
        // 例えば、シーンの切り替え:
        // SceneManager.LoadScene("VictoryScene");
    }
}
