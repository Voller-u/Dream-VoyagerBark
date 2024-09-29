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
    [Header("��������")]
    private CardType type;
    [Header("ͨ�õ�������")]
    public int normalExpense;
    [Header("��ɫ�����������")]
    public int speicalExpense;



}
