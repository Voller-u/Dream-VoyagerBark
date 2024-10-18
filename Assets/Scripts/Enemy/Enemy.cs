using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    public int atk;
    public int def;
    public int maxHp;

    public Slider healthSlider;

    [SerializeField]
    private int curHp;
    public int CurHp
    {
        get => curHp;
        set
        {
            curHp = Mathf.Clamp(value, 0, maxHp);
            healthSlider.value = (float)curHp / maxHp;
        }
    }
    public int shield;

    public BTNode root;

    protected new virtual void Start()
    {
        base.Start();
        CurHp = maxHp;
        EnemyManager.Instance.enemyList.Add(this);
        EnemyManager.Instance.targetEnemy = this;

        InitBT();
    }

    public virtual void Hurt(int damage)
    {
        int rem = shield - damage;
        if(rem <= 0)
        {
            CurHp = Mathf.Clamp(curHp + rem,0, maxHp);
        }
        else
        {
            shield -= damage;
        }
    }

    public virtual void Act()
    {

    }

    public virtual void InitBT()
    {
        
    }

}
