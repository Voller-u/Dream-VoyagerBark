using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class FightWIn : FightUnit
{
    public override void Init()
    {
        
        FightWinUI fightWinUI = UIManager.Instance.ShowUI<FightWinUI>("FightWinUI") as FightWinUI; ;

        MapNodeType type = UIManager.Instance.GetUI<MapUI>("MapUI").mapInfo.curMapNode.type;
        switch (type)
        {
            case MapNodeType.Boss:
                fightWinUI.winText.text = "ͨ������";
                fightWinUI.ButtonText.text = "�������˵�";
                fightWinUI.toNextLevelBtn.onClick.RemoveAllListeners();
                fightWinUI.toNextLevelBtn.onClick.AddListener(() =>
                {
                    EventManager.Instance.LoadScene("MainMenu");
                    File.Delete(MapUI.path);
                });
                break;
            case MapNodeType.Monster:
                int obtainGoldNum = Random.Range(10, 20);
                fightWinUI.winText.text = $"Ӯ�ˣ����{obtainGoldNum}���";
                RoleManager.Instance.ObtainGold(obtainGoldNum);
                break;
        }
    }

    public override void OnUpdate()
    {

    }


}
