using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy : FightUnit
{
    public override void Init()
    {
        //禁掉玩家对卡牌的交互
        UIManager.Instance.SetInteractableUI("FightUI", false);

        EnemyManager.Instance.actEnemy.Act();

        FightManager.Instance.ChangeType();
    }

    public override void OnUpdate()
    {
       
    }
}
