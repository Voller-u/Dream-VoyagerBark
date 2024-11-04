using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IMonster { }
public interface IInfernalMob { }
public interface IBoss { }
public class Enemy : Character
{
    public int atkBase;
    public int atk;
    public int defBase;
    public int def;
    public int maxHp;

    public bool actOver = false;

    public RectTransform healthBar;
    private float healthBarX;

    public GameObject parentGameObject;

    [HideInInspector]
    public Material normalMaterial;
    public Material targetMaterial;
    [HideInInspector]
    public SpriteRenderer sprite;

    [SerializeField]
    private int curHp;
    public int CurHp
    {
        get => curHp;
        set
        {
            curHp = Mathf.Clamp(value, 0, maxHp);
            

            healthBar.localPosition = new Vector3(healthBarX - healthBar.rect.width * (1-(float)curHp / maxHp), healthBar.localPosition.y, healthBar.localPosition.z);
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
        sprite = GetComponent<SpriteRenderer>();
        normalMaterial = sprite.material;
        base.Start();
        CurHp = maxHp;
        atk = atkBase;
        def = defBase;
        EnemyManager.Instance.enemyList.Add(this);
        EnemyManager.Instance.targetEnemy = this;

        InitBT();

        healthBarX = healthBar.localPosition.x;

        
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
        Destroy(parentGameObject);
    }

    public void SetActOver()
    {
        actOver = true;
    }

}
