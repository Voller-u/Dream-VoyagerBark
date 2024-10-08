using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[Serializable]
public class CardBase:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    //public CardData data;

    public virtual void Effect()
    {

    }

    public virtual void Effect(Role role)
    {

    }
    public virtual void Effect(Enemy enemy) 
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
}
