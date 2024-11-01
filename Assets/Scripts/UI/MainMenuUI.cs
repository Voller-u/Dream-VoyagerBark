using System.Collections;
using System.Collections.Generic;
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
        //TODO �ж��Ƿ���δ���ս����������ʾ������Ϸ��ť

        StartGameButton.onClick.AddListener(() => EventManager.Instance.LoadScene("Game"));


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