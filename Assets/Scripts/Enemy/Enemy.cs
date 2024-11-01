using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IMonster { }
public interface IInfernalMob { }
public interface IBoss { }
public class Enemy : Character
{
    public int atk;
    public int def;
    public int maxHp;

    public bool actOver = false;

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

            if(curHp <=0)
            {
                //¹ÖÎïËÀÍö
                Dead();
            }
        }
    }

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

    public virtual void Act()
    {

    }

    public virtual void InitBT()
    {
        
    }

    public virtual void Dead()
    {
        EnemyManager.Instance.enemyList.Remove(this);
        if (this == EnemyManager.Instance.targetEnemy)
            EnemyManager.Instance.ChangeTarget();
        Destroy(gameObject);
    }

    public void SetActOver()
    {
        actOver = true;
    }

}
