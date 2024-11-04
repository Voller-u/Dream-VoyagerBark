using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    [SerializeField]
    [Header("��������")]
    private CardType type;
    [Header("ͨ�õ�������")]
    public int normalExpense;
    [Header("��ɫ�����������")]
    public int speicalExpense;


    private float weight;

    public virtual void Effect()
    {

    }
}
