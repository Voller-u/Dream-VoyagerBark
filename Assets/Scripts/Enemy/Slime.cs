using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy
{
    private Animator anim;

    

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
            anim.SetTrigger("Action1");
            Debug.Log("执行行动1");
        });

        BT.Action act2 = entry.AddChild(new BT.Action("Act2")) as BT.Action;
        act2.precondition = () => CurHp <= maxHp / 2;
        act2.SetAction(() =>
        {
            anim.SetTrigger("Action2");
            Debug.Log("执行行动2");
        });
    }

    public void Attack()
    {
        RoleManager.Instance.role.Hurt(atk);
        //anim.ResetTrigger("Action1");
    }

    public void AddHealth()
    {
        CurHp += 3;
        //anim.ResetTrigger("Action2");
    }
}
