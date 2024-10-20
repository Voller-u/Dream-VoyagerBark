using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightWinUI : UIBase
{
    public Button toNextLevelBtn;

    public void ToNextLvel()
    {
        MapUI map = UIManager.Instance.ShowUI<MapUI>("MapUI") as MapUI;
        if(map != null )
        {
            map.ToNextLayer();
        }
    }
}
