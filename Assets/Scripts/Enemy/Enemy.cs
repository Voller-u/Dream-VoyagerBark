using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int atk;
    public int def;
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
    public int shield;

    protected new virtual void Start()
    {
        base.Start();
        curHp = maxHp/2;
        EnemyManager.Instance.enemyList.Add(this);
        EnemyManager.Instance.targetEnemy = this;
    }

    public virtual void Hurt(int atk)
    {
        int rem = shield - atk;
        if(rem <= 0)
        {
            curHp = Mathf.Clamp(curHp - rem,0, maxHp);
        }
        else
        {
            shield -= atk;
        }
    }

    public virtual void Act()
    {

    }

}
