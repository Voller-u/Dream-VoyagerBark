using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ¹¥»÷ÅÆ
/// </summary>
public class AttackCard : Card
{

    [Header("¹¥»÷±¶ÂÊ")]
    public float atk = 0.1f;

    public override void Effect()
    {
        Enemy enemy = EnemyManager.Instance.targetEnemy;
        enemy.Hurt(10 + (int)(Mathf.Round(RoleManager.Instance.role.atk * atk)));
    }
}
