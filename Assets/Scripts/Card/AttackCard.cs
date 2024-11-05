using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackCard { }

/// <summary>
/// ¹¥»÷ÅÆ
/// </summary>
[Serializable]
public class AttackCard : Card, IAttackCard
{

    [Header("¹¥»÷±¶ÂÊ")]
    public float atk = 0.1f;

    public override void Effect()
    {
        Enemy enemy = EnemyManager.Instance.targetEnemy;
        enemy.Hurt(10 + (int)(Mathf.Round(RoleManager.Instance.role.atk * atk)));
    }
}

/// <summary>
/// ÖØÅü
/// </summary>
[Serializable]
public class HeavyChopCard : Card, IAttackCard
{
    public float atk = 0.2f;

    public override void Effect()
    {
        Enemy enemy = EnemyManager.Instance.targetEnemy;
        enemy.Hurt(30 + (int)(Mathf.Round(RoleManager.Instance.role.atk * atk)));
    }
}

/// <summary>
/// ºáÉ¨
/// </summary>
[Serializable]
public class SweepCard: Card, IAttackCard
{
    public float atk = 0.05f;

    public override void Effect()
    {
        int damage = (int)(12 + atk * RoleManager.Instance.role.atk);
        for (int i = EnemyManager.Instance.enemyList.Count - 1; i >= 0; i--) 
        {
            EnemyManager.Instance.enemyList[i].Hurt(damage);
        }
    }
}