using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    [SerializeField]
    [Header("卡牌类型")]
    private CardType type;
    [Header("通用点数费用")]
    public int normalExpense;
    [Header("角色自身点数费用")]
    public int speicalExpense;


    private float weight;

    public virtual void Effect()
    {

    }
}
