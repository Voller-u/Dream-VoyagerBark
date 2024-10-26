using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginUI : UIBase
{
    public Button startButton;
    public Button quitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(() => SceneManager.LoadScene("Game"));

        quitButton.onClick.AddListener(()=>Application.Quit());
    }
}
