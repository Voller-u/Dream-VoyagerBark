using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : CardBase
{

    [Header("¹¥»÷±¶ÂÊ")]
    public float atk;

    public override void Effect()
    {
        Enemy enemy = EnemyManager.Instance.targetEnemy;
        enemy.Hurt((int)(Mathf.Round(RoleManager.Instance.role.atk * atk)));
    }
}
