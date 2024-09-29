using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    ATK,
    DEF,
    SKL,
    BUFF
}

[CreateAssetMenu(menuName = "ScriptableObject/CardData", fileName = "NewCardData")]
public class CardData : ScriptableObject
{
    [SerializeField]
    [Header("卡牌类型")]
    private CardType type;
    [Header("通用点数费用")]
    public int normalExpense;
    [Header("角色自身点数费用")]
    public int speicalExpense;



}
