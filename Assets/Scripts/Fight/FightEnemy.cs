using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy : FightUnit
{
    public override void Init()
    {
        //禁掉玩家对卡牌的交互
        UIManager.Instance.SetInteractableUI("FightUI", false);

        GameManager.Instance.GameStartCoroutine(EnemyAct());
    }

    public override void OnUpdate()
    {
       
    }

    IEnumerator EnemyAct()
    {
        EnemyManager.Instance.actEnemy.InvokeBeginAction();
        EnemyManager.Instance.actEnemy.Act();
        yield return new WaitUntil(() => EnemyManager.Instance.actEnemy.actOver);
        EnemyManager.Instance.actEnemy.InvokeEndAction();

        EnemyManager.Instance.actEnemy.actOver = false;

        FightManager.Instance.ChangeType();
    }
}
