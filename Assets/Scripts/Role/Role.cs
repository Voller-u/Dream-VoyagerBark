using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    public int atk;
    public int def;
    public int spd;
    public int maxHp;
    public int curHp;

    public int maxPower;
    public int curPower;

    public int maxSpecialPower;
    public int curSpecialPower;

    /// <summary>
    /// 回合开始时的初始化
    /// </summary>
    public virtual void Init()
    {
        curPower = maxPower;
        curSpecialPower = maxSpecialPower;
    }
}
