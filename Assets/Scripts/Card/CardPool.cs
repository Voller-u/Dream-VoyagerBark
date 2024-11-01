using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardPool : MonoBehaviour
{
    public static CardPool Instance;

    public List<CardItem> cards = new List<CardItem>();
    private void Awake()
    {
        Instance = this;
    }

    public CardItem GetCard()
    {
        if(cards.Count == 0)
        {
            GameObject _cardItem = Instantiate(Resources.Load<GameObject>("Cards/Card"), transform);
            _cardItem.SetActive(false);
            CardItem cardItem = _cardItem.GetComponent<CardItem>();
            cards.Add(cardItem);
        }
        CardItem card = cards[^1];
        cards.RemoveAt(cards.Count - 1);
        return card;
    }

    public void HideCard(CardItem card)
    {
        card.transform.SetParent(transform);
        card.gameObject.SetActive(false);
        cards.Add(card);
    }
}
