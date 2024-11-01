using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropertyUI : UIBase
{
    public Text roleName;
    public Text healthText;
    public Text goldText;

    public Button map;
    public Button cards;
    public Button setting;

    public GameObject SettingUI;

    private void Awake()
    {
        map.onClick.AddListener(() => UIManager.Instance.ShowUI<MapUI>("MapUI"));

        setting.onClick.AddListener(() =>
        {
            SettingUI.SetActive(!SettingUI.activeSelf);
        });

        EventManager.Instance.OnPropertyChangeEvent += Refresh;
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnPropertyChangeEvent -= Refresh;
    }

    public void Refresh(Role role)
    {
        roleName.text = role.name.Replace("(clone)", "");
        healthText.text = $"{role.CurHp} / {role.maxHp}";
        goldText.text = role.Gold.ToString();
    }
}