using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightCardManager : MonoBehaviour
{
    public static FightCardManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public int drawCardNum;

    /// <summary>
    /// 战斗过程中在牌堆里的卡牌集合
    /// </summary>
    public List<Card> unusedCardList = new List<Card>();
    /// <summary>
    /// 战斗过程中在弃牌堆里的卡牌集合
    /// </summary>
    public List<Card> usedCardList = new List<Card>();
    /// <summary>
    /// 战斗过程中被消耗的的卡牌集合
    /// </summary>
    public List<Card> exhaustedCardList = new List<Card>();

    /// <summary>
    /// 手牌集合
    /// </summary>
    public List<CardItem> cardList = new List<CardItem>();

    public Transform pocket; 


    public void Init()
    {


        drawCardNum = 5;
        unusedCardList.Clear();
        usedCardList.Clear();
        exhaustedCardList.Clear();
        RemoveAllCards();
        cardList.Clear();

        //TODO 优化
        pocket = FindObjectOfType<Pocket>().transform;

        unusedCardList.AddRange(RoleManager.Instance.cardList);
        Tools.Shuffle(unusedCardList);
    }

    public bool HaveCard()
    {
        return unusedCardList.Count > 0;
    }

    public CardItem DrawCard()
    {
        if(!HaveCard())
        {
            unusedCardList.AddRange(usedCardList);
            usedCardList.Clear();
            Tools.Shuffle<Card>(unusedCardList);
        }
        Card card = unusedCardList[^1];
        unusedCardList.RemoveAt(unusedCardList.Count - 1);
        CardItem cardItem = CardPool.Instance.GetCard();
        cardItem.card = card;
        return cardItem;
    }

    

    /// <summary>
    /// 从牌库中抽牌加入到手牌中
    /// </summary>
    /// <param name="num">要抽取的数量</param>
    public void AddCard(int num = 1)
    {
        for(int i=0;i< num; i++)
        {
            CardItem card = DrawCard();
            cardList.Add(card);
            card.Interactable = true;
            card.gameObject.transform.SetParent(pocket, false);
            card.gameObject.transform.localScale = Vector3.one;
            card.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 去除指定索引的手牌
    /// </summary>
    /// <param name="index"></param>
    public void RemoveCard(int index)
    {
        CardItem card = cardList[index];
        cardList.RemoveAt(index);
        usedCardList.Add(card.card);
        CardPool.Instance.HideCard(card);
        //TODO 播放动画
        //StartCoroutine(RemoveCardCoroutine(card));
    }

    public void RemoveCard(CardItem card)
    {
        for(int i=0;i<cardList.Count;i++)
        {
            if (cardList[i] == card)
            {
                RemoveCard(i);
                break;
            }
        }
    }

    IEnumerator RemoveCardCoroutine(CardItem card)
    {
        yield return null;
        card.gameObject.SetActive(false);

    }

    /// <summary>
    /// 移除所有手牌
    /// </summary>
    public void RemoveAllCards()
    {
        while (cardList.Count > 0)
        {
            RemoveCard(0);
        }
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCard();
        }
    }

    

}
