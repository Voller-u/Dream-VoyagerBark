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

    private void Awake()
    {
        map.onClick.AddListener(() => UIManager.Instance.ShowUI<MapUI>("MapUI"));
    }
}
