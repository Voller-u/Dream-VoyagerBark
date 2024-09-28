using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvas;
    //´æ´¢¼ÓÔØ¹ýµÄUI
    public Dictionary<string, UIBase> UIDic;

    private void Awake()
    {
        Instance = this;
        canvas = GetComponent<Transform>();
        UIDic = new();
    }

    public UIBase ShowUI<T>(string uiName) where T : UIBase
    {
        UIBase ui;
        if(UIDic.ContainsKey(uiName))
        {
            ui = UIDic[uiName];
        }
        else
        {
            GameObject obj = Instantiate(Resources.Load<GameObject>("UI/" + uiName),canvas);

            obj.name = uiName;

            ui = obj.GetComponent<UIBase>();

            UIDic[uiName] = ui;
        }

        ui.Show();
        return ui;
    }

    public void HideUI(string uiName)
    {
        UIDic[uiName]?.Hide();
    }

    public void CloseUI(string uiName)
    {
        if(UIDic.ContainsKey(uiName))
        {
            UIDic[uiName].Close();
            UIDic.Remove(uiName);
        }
    }

    public void CloseAllUI()
    {
        foreach(UIBase ui in UIDic.Values)
        {
            ui.Close();
        }
        UIDic.Clear();
    }
}
