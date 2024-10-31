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


    /// <summary>
    /// 战斗过程中在牌堆里的卡牌集合
    /// </summary>
    public List<CardItem> unusedCardList;
    /// <summary>
    /// 战斗过程中在弃牌堆里的卡牌集合
    /// </summary>
    public List<CardItem> usedCardList;
    /// <summary>
    /// 战斗过程中被消耗的的卡牌集合
    /// </summary>
    public List<CardItem> exhaustedCardList;

    /// <summary>
    /// 手牌集合
    /// </summary>
    public List<CardItem> cardList;

    public Transform pocket; 


    public void Init()
    {
        unusedCardList = new List<CardItem>();
        usedCardList = new List<CardItem>();
        exhaustedCardList = new List<CardItem>();
        cardList = new List<CardItem>();

        //TODO 优化
        pocket = FindObjectOfType<Pocket>().transform;

        unusedCardList.AddRange(RoleManager.Instance.cardItems);
        Tools.Shuffle(unusedCardList);
    }

    public bool HaveCard()
    {
        return unusedCardList.Count > 0;
    }

    public GameObject DrawCard()
    {
        if(!HaveCard())
        {
            unusedCardList.AddRange(usedCardList);
            usedCardList.Clear();
            Tools.Shuffle<CardItem>(unusedCardList);
        }
        CardItem card = unusedCardList[^1];
        unusedCardList.RemoveAt(unusedCardList.Count - 1);
        return card.gameObject;
    }

    

    /// <summary>
    /// 从牌库中抽牌加入到手牌中
    /// </summary>
    /// <param name="num">要抽取的数量</param>
    public void AddCard(int num = 1)
    {
        for(int i=0;i< num; i++)
        {
            GameObject obj = DrawCard();
            CardItem card = obj.GetComponent<CardItem>();
            cardList.Add(card);
            card.Interactable = true;
            obj.transform.SetParent(pocket, false);
            obj.transform.localScale = Vector3.one;
            obj.SetActive(true);
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
        usedCardList.Add(card);
        card.transform.SetParent(pocket.parent, false);
        card.gameObject.SetActive(false);
        
        card.transform.SetParent(GameObject.Find("TrashCan").transform);
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
