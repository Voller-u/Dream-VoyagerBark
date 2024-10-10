using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

[Serializable]
public class CardBase:MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    //public CardData data;
    [SerializeField]
    [Header("��������")]
    private CardType type;
    [Header("ͨ�õ�������")]
    public int normalExpense;
    [Header("��ɫ�����������")]
    public int speicalExpense;

    public virtual void Effect()
    {

    }

    public virtual void Effect(Role role)
    {

    }
    public virtual void Effect(Enemy enemy) 
    {

    }

    public virtual void Effect(Enemy[] enemies)
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
        switch(type)
        {
            case CardType.ATK:
                Effect(EnemyManager.Instance.targetEnemy);
                break;
            case CardType.DEF:
                break;
            case CardType.SKL:
                break;
            case CardType.BUFF:
                break;
        }
    }
}
