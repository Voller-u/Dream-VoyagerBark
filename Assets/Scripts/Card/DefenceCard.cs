using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceCard : Card
{
    public float def = 0.2f;


    public override void Effect()
    {
        RoleManager.Instance.role.shield += 5 + (int)(def * RoleManager.Instance.role.def);
    }
}
