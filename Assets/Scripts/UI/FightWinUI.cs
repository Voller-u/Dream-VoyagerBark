using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightWinUI : UIBase
{
    public Button toNextLevelBtn;

    private void Awake()
    {
        toNextLevelBtn.onClick.AddListener(ToNextLvel);
    }

    public void ToNextLvel()
    {
        MapUI map = UIManager.Instance.ShowUI<MapUI>("MapUI") as MapUI;
        if(map != null )
        {
            map.ToNextLayer();
        }
        UIManager.Instance.HideUI("FightWinUI");
    }
}
