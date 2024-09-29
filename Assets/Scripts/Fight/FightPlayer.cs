using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer : FightUnit
{
    public override void Init()
    {
        Debug.Log("玩家回合");
        UIManager.Instance.ShowTip("玩家回合", Color.black, delegate ()
        {
            //抽牌
            Debug.Log("从牌堆中抽牌");
        });
    }

    public override void OnUpdate()
    {
        
    }
}
