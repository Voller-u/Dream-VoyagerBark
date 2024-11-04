using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightWinUI : UIBase
{
    public Button toNextLevelBtn;
    public Text ButtonText;

    public Text winText;

    private void Awake()
    {
        toNextLevelBtn.onClick.AddListener(ToNextLvel);
    }

    public void ToNextLvel()
    {
        MapUI map = UIManager.Instance.GetUI<MapUI>("MapUI") as MapUI;
        if(map != null )
        {
            map.ToNextLayer();
            map.Show();
        }
        UIManager.Instance.HideUI("FightWinUI");

        //TODO ¥Ú…®’Ω≥°
    }
}
