using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

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

    private CardTip _cardTip;

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
        transform.DOScale(2f, 0.25f);
        index = transform.GetSiblingIndex();
        transform.SetAsLastSibling();
        _cardTip =  Instantiate(Resources.Load("UI/CardTip"),transform).GetComponent<CardTip>();
        
        if(CardDataManager.Instance.cardTipDic.ContainsKey(card.GetType().Name))
        {
            _cardTip.Init(CardDataManager.Instance.cardTipDic[card.GetType().Name]);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, 0.25f);
        transform.SetSiblingIndex(index);
        if(_cardTip != null)
        {
            Destroy(_cardTip.gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!Interactable)
            return;
        Effect();
        EventManager.Instance.OnCardPlay(card);
        FightCardManager.Instance.RemoveCard(this);
    }

    public void SetDefault()
    {
        transform.localScale = Vector3.one;
        if (_cardTip != null)
        {
            Destroy(_cardTip.gameObject);
        }
    }
}
