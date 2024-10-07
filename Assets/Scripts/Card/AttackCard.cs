using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : CardBase
{
    [SerializeField]
    [Header("卡牌类型")]
    private CardType type;
    [Header("通用点数费用")]
    public int normalExpense;
    [Header("角色自身点数费用")]
    public int speicalExpense;

    [Header("攻击倍率")]
    public float atk;

    public override void Effect(Enemy enemy)
    {
        enemy.Hurt((int)(Mathf.Round(RoleManager.Instance.role.atk * atk)));
    }
}
