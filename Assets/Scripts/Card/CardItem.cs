using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

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
    [SerializeField]
    private Card _card;
    public Card card
    {
        get => _card;
        set
        {
            _card = value;
            string cardName = _card.GetType().Name;
            Sprite sprite = Resources.Load<Sprite>("Cards/" + cardName);
            cardImage.sprite = sprite;
        }
    }
    public Image cardImage;

    public bool Interactable = false;

    public virtual void Effect()
    {
        card.Effect();
    }

    private void Awake()
    {
        cardImage = GetComponent<Image>();
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
