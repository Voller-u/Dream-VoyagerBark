using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Role : MonoBehaviour
{
    public int atk;
    public int def;
    public int spd;
    public int maxHp;
    [SerializeField]
    private int curHp;
    public int CurHp
    {
        get => curHp;
        set
        {
            curHp = Mathf.Clamp(value, 0, maxHp);
        }
    }

    public int maxPower;
    [SerializeField]
    private int curPower;
    public int CurPower
    {
        get => curPower;
        set
        {
            curPower = Mathf.Clamp(value, 0, maxPower);
        }
    }

    public int maxSpecialPower;
    [SerializeField]
    private int curSpecialPower;
    public int CurSpecialPower
    {
        get => curSpecialPower;
        set
        {
            curSpecialPower = Mathf.Clamp(value, 0, maxSpecialPower);
        }
    }

    /// <summary>
    /// 回合开始时的初始化
    /// </summary>
    public virtual void Init()
    {
        curPower = maxPower;
        curSpecialPower = maxSpecialPower;
    }
}
