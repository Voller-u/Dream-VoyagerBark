using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCard : CardBase
{
    [SerializeField]
    [Header("��������")]
    private CardType type;
    [Header("ͨ�õ�������")]
    public int normalExpense;
    [Header("��ɫ�����������")]
    public int speicalExpense;

    [Header("��������")]
    public float atk;

    public override void Effect(Enemy enemy)
    {
        enemy.Hurt((int)(Mathf.Round(RoleManager.Instance.role.atk * atk)));
    }
}
