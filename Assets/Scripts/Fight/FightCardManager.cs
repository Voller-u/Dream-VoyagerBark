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
    public List<CardBase> unusedCardList;
    /// <summary>
    /// 战斗过程中在弃牌堆里的卡牌集合
    /// </summary>
    public List<CardBase> usedCardList;
    /// <summary>
    /// 战斗过程中被消耗的的卡牌集合
    /// </summary>
    public List<CardBase> exhaustedCardList;

    /// <summary>
    /// 手牌集合
    /// </summary>
    public List<CardBase> cardList;

    public Transform pocket; 


    public void Init()
    {
        unusedCardList = new List<CardBase>();
        usedCardList = new List<CardBase>();
        exhaustedCardList = new List<CardBase>();
        cardList = new List<CardBase>();

        //TODO 优化
        pocket = FindObjectOfType<Pocket>().transform;

        unusedCardList.AddRange(RoleManager.Instance.cardList);
        Shuffle(unusedCardList);
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
            Shuffle<CardBase>(unusedCardList);
        }
        CardBase card = unusedCardList[^1];
        unusedCardList.RemoveAt(unusedCardList.Count - 1);
        return card.gameObject;
    }

    //洗牌
    void Shuffle<T>(List<T> array)
    {
        int n = array.Count;

        for (int i = 0; i < n; i++)
        {

            int r = i + UnityEngine.Random.Range(0, n - i);

            T t = array[r];

            array[r] = array[i];

            array[i] = t;

        }
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
            CardBase card = obj.GetComponent<CardBase>();
            cardList.Add(card);
            obj.transform.SetParent(pocket, false);
            obj.SetActive(true);
        }
    }

    /// <summary>
    /// 去除指定索引的手牌
    /// </summary>
    /// <param name="index"></param>
    public void RemoveCard(int index)
    {
        CardBase card = cardList[index];
        cardList.RemoveAt(index);
        usedCardList.Add(card);
        card.transform.SetParent(pocket.parent, false);
        card.gameObject.SetActive(false);
        //StartCoroutine(RemoveCardCoroutine(card));
    }

    IEnumerator RemoveCardCoroutine(CardBase card)
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
