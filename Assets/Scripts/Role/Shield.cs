using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield:IComparable<Shield>
{
    /// <summary>
    /// ����ֵ
    /// </summary>
    public int num;

    /// <summary>
    /// ʣ��غ���
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