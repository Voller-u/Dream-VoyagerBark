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
    public int gold;
    public int Gold
    {
        get => gold;
        set
        {
            if(value > gold)
            {
                int obtainNum = value - gold;
                Debug.Log("角色获得金币");
                EventManager.Instance.OnGoldObtain(obtainNum);
            }
            gold = value;
            EventManager.Instance.OnPropertyChange(this);
        }
    }

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
            EventManager.Instance.OnPropertyChange(this);
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

    protected new virtual void Start()
    {
        base.Start();
        CurHp = maxHp;
        RoleManager.Instance.role = this;
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
        while (damage > 0 && shield.Count > 0)
        {
            if (damage <= shield[^1].num)
            {
                shield[^1].num -= damage;
                if (shield[^1].num == 0)
                    shield.RemoveAt(shield.Count - 1);
            }
            else
            {
                damage -= shield[^1].num;
                shield.RemoveAt(shield.Count - 1);
            }
        }
        if (damage > 0)
        {
            CurHp -= damage;
        }
    }
}
