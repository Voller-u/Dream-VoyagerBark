using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void RoundAction();

/// <summary>
/// ս����Ԫ
/// </summary>
public class FightUnit 
{
    

    //��ʼ��
    public virtual void Init()
    {

    }
    //ÿִ֡��
    public virtual void OnUpdate()
    {

    }

    public void AddRoundBegin(RoundAction action)
    {

    }
}
