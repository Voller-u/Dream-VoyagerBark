using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    public override void Hurt(int atk)
    {
        base.Hurt(atk);
    }

    public override void Act()
    {
        root.Tick();
    }

    public override void InitBT()
    {
        root = new BT.Parallel("Root");
        BTNode entry = root.AddChild(new BT.Parallel("Entry"));
        BT.Action act1 = entry.AddChild(new BT.Action("Act1")) as BT.Action; 
        act1.precondition = () => CurHp > maxHp / 2;
        act1.SetAction(() =>
        {
            RoleManager.Instance.role.Hurt(atk);
            Debug.Log("执行行动1");
        });

        BT.Action act2 = entry.AddChild(new BT.Action("Act2")) as BT.Action;
        act2.precondition = () => CurHp <= maxHp / 2;
        act2.SetAction(() =>
        {
            CurHp += 3;
            Debug.Log("执行行动2");
        });
    }
}
