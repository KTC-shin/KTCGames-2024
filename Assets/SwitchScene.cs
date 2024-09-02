using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public void MainSwitchScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    public void OptionSwitchScene()
    {
        SceneManager.LoadScene("OptionScene", LoadSceneMode.Single);
    }
    public void TitleSwitchScene()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
    }
    public void ClearSwitchScene()
    {
        SceneManager.LoadScene("ClearScene", LoadSceneMode.Single);
    }
    public void GameOverSwitchScene()
    {
        SceneManager.LoadScene("GameOverScene", LoadSceneMode.Single);
    }
}
