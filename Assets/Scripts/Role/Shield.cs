using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield:IComparable<Shield>
{
    /// <summary>
    /// 护盾值
    /// </summary>
    public int num;

    /// <summary>
    /// 剩余回合数
    /// </summary>
    public int round;

    public Shield(int num, int round)
    {
        this.num = num;
        this.round = round;
    }

    public int CompareTo(Shield other)
    {
        return -round.CompareTo(other.round);
    }
}

public class ShieldList<Shield>:List<Shield>
{
    public new void Add(Shield item)
    {
        base.Add(item);
        Sort();
    }


}