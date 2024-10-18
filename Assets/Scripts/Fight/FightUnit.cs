using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void RoundAction();

/// <summary>
/// 战斗单元
/// </summary>
public class FightUnit 
{
    

    //初始化
    public virtual void Init()
    {

    }
    //每帧执行
    public virtual void OnUpdate()
    {

    }

    public void AddRoundBegin(RoundAction action)
    {

    }
}
