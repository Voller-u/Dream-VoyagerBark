using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : UIBase
{
    public Button ResumeGameButton;
    public Button StartGameButton;
    public Button ArchiveButton;
    public Button SettingButton;
    public Button ArchievementButton;
    public Button ExitGameButton;

    private void Awake()
    {
        //TODO 判断是否有未完成战斗，有则显示继续游戏按钮
        if(File.Exists(MapUI.path))
        {
            ResumeGameButton.gameObject.SetActive(true);
        }

        ResumeGameButton.onClick.AddListener(() =>
        {
            EventManager.Instance.LoadScene("Game");
        });

        StartGameButton.onClick.AddListener(() => {
            EventManager.Instance.LoadScene("Game");
            File.Delete(MapUI.path);
            File.Delete(RoleManager.path);
        });


        ExitGameButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
    }
}
