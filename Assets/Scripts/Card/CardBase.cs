using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public enum CardType
{
    ATK,
    MulAtk,
    DEF,
    SKL,
    BUFF
}

[Serializable]
public class CardBase:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    //public CardData data;
    [SerializeField]
    [Header("卡牌类型")]
    private CardType type;
    [Header("通用点数费用")]
    public int normalExpense;
    [Header("角色自身点数费用")]
    public int speicalExpense;

    private float weight;

    public bool Interactable = false;

    public virtual void Effect()
    {

    }

    

    private int index;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(1.5f, 0.25f);
        index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.25f);
        transform.SetSiblingIndex(index);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!Interactable)
            return;
        Effect();
        //switch(type)
        //{
        //    case CardType.ATK:
        //        Effect(EnemyManager.Instance.targetEnemy);
        //        break;
        //    case CardType.MulAtk:
        //        Effect(EnemyManager.Instance.enemyList);
        //        break;
        //    case CardType.DEF:
        //        Effect();
        //        break;
        //    case CardType.SKL:
        //        Effect();
        //        break;
        //    case CardType.BUFF:
        //        Effect();
        //        break;
        //}
        FightCardManager.Instance.RemoveCard(this);
    }
}
