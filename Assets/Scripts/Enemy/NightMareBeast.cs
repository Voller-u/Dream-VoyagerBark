using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NightMareBeast : Enemy
{
    private List<Action> actionList = new List<Action>();
    private int actIndex1 = 0;
    private int[] loop1 = { 0, 0, 1 };
    private int actIndex2= 0;
    private int[] loop2 = { 2, 0, 1 };
    public override void Act()
    {
        if(CurHp >= maxHp/2)
        {
            actionList[loop1[actIndex1]].Invoke();
            actIndex1++;
            actIndex1 %= loop1.Length;
        }
        else
        {
            actionList[loop2[actIndex2]].Invoke();
            actIndex2++;
            actIndex2 %= loop2.Length;
        }
        actOver = true;
    }

    public override void InitBT()
    {

        actionList.Add(() => RoleManager.Instance.role.Hurt((int)(5 + 0.1f * atk)));
        actionList.Add(() => RoleManager.Instance.role.Hurt((int)(8 + 0.1f * atk)));
        actionList.Add(() =>
        {
            RoleManager.Instance.role.Hurt((int)(8 + 0.1f * atk));
            AddShield(new Shield((int)(2 + 0.1f * atk), 1));
        });
        actionList.Add(() => AddBuff(new Buff(() => spd += 20, () => spd -= 20, 2)));
    }
}
