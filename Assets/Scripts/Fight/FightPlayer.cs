using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer : FightUnit
{


    public override void Init()
    {
        //UIManager.Instance.ShowTip("玩家回合", Color.black, delegate ()
        //{
            
        //});
        //抽牌
        Debug.Log("从牌堆中抽牌");
        FightCardManager.Instance.AddCard();
        UIManager.Instance.SetInteractableUI("FightUI", true);

        RoleManager.Instance.role.InvokeBeginAction();
    }

    public override void OnUpdate()
    {
        
    }
}
