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
public class CardItem:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    //public CardData data;
    public Card card;

    public bool Interactable = false;

    public virtual void Effect()
    {
        card.Effect();
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
