using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy : FightUnit
{
    public override void Init()
    {
        //������ҶԿ��ƵĽ���
        UIManager.Instance.SetInteractableUI("FightUI", false);

        EnemyManager.Instance.actEnemy.InvokeBeginAction();

        EnemyManager.Instance.actEnemy.Act();

        EnemyManager.Instance.actEnemy.InvokeEndAction();
        FightManager.Instance.ChangeType();
    }

    public override void OnUpdate()
    {
       
    }
}
