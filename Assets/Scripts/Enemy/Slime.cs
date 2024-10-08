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
        CurHp += 3;
    }
}
