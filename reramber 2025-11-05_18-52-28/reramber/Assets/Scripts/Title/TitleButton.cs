using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{
    #region 씬이름들
    private const string LobbySceneName = "MainLobbyScenes";
    private const string TitleSceneName = "TitleScenes";
    private const string IngameScenes = "IngameScenes";
    #endregion
    [SerializeField] private GameObject settingpanle;
    public void NewGameStart()
    {
        LoadingScene.LoadScene(LobbySceneName);
    }
    public void GameENDButton()
    {
        // 게임 종료

#if UNITY_EDITOR
        // Stops play mode in the Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Quits the application when built
            Application.Quit();
#endif
    }
    public void SettingButton()
    {
        settingpanle.gameObject.SetActive(true);
    }

}
