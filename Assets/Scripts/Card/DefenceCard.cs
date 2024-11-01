using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DefenceCard : Card
{
    public float def = 0.2f;


    public override void Effect()
    {
        Role role = RoleManager.Instance.role;
        role.AddShield(new Shield(5 + (int)(def * role.def), 1));
    }
}

/// <summary>
/// Ó²»¯
/// </summary>
[Serializable]
public class HardenCard : Card
{
    public float def = 0.2f;

    public override void Effect()
    {
        Role role = RoleManager.Instance.role;
        role.AddShield(new Shield(15 + (int)(def * role.def), 1));
        for(int i=0;i<role.shield.Count;i++)
        {
            role.shield[i].round++;
        }
    }
}

