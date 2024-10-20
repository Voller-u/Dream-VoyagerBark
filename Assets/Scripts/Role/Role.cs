using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Role : Character
{
    public int atk;
    public int def;
    public int maxHp;

    public Slider healthSlider;

    [SerializeField]
    protected int curHp;
    public  int CurHp
    {
        get => curHp;
        set
        {
            curHp = Mathf.Clamp(value, 0, maxHp);
            healthSlider.value = (float)curHp / maxHp;
            if(curHp <=0)
            {
                FightManager.Instance.ChangeType(FightType.Lose);
            }
        }
    }
    public int shield;

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

    protected new virtual void Start()
    {
        base.Start();
        CurHp = maxHp;
    }

    /// <summary>
    /// 回合开始时的初始化
    /// </summary>
    public virtual void Init()
    {
        curPower = maxPower;
        curSpecialPower = maxSpecialPower;
    }


    public virtual void Hurt(int damage)
    {
        int rem = shield - damage;
        if (rem <= 0)
        {
            CurHp = Mathf.Clamp(curHp + rem, 0, maxHp);
        }
        else
        {
            shield -= damage;
        }
    }
}
