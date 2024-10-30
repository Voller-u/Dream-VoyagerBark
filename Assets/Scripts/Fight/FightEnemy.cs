using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightEnemy : FightUnit
{
    public override void Init()
    {
        //������ҶԿ��ƵĽ���
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
