using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ս����ʼ��
/// </summary>
public class FightInit : FightUnit
{

    public override void Init()
    {
        FightCardManager.Instance.Init();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
