using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// º”ÀŸ
/// </summary>
[Serializable]
public class SpeedUpCard : Card
{
    public float spd = 0.1f;

    public override void Effect()
    {
        Role role = RoleManager.Instance.role;

        int calRes = (int)(spd * role.spd + 20);

        Buff buff = new Buff(() => role.spd += calRes, () => role.spd -= calRes, 2);
        role.AddBuff(buff);
    }
}