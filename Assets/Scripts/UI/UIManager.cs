using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Transform canvas;
    //存储加载过的UI
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

    public void ShowTip(string tip,Color color,Action callback = null)
    {
        //obj为提示的物体
        GameObject obj = null;

        Tween scale1 = obj.transform.DOScale(1, 0.2f);
        Tween scale2 = obj.transform.DOScale(0, 0.2f);

        Sequence seq = DOTween.Sequence();
        seq.Append(scale1);
        seq.AppendInterval(0.5f);
        seq.Append(scale2);
        seq.AppendCallback(delegate ()
        {
            callback?.Invoke();
        });

    }
}
