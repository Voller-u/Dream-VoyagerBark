using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager : BaseManager<FightCardManager>
{
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

    public void Init()
    {
        unusedCardList = new List<CardBase>();
        usedCardList = new List<CardBase>();
        exhaustedCardList = new List<CardBase>();
    }

    public bool HaveCard()
    {
        return unusedCardList.Count > 0;
    }

    public CardBase DrawCard()
    {
        if(!HaveCard())
        {
            unusedCardList.AddRange(usedCardList);
            usedCardList.Clear();
            Shuffle<CardBase>(unusedCardList);
        }
        CardBase card = unusedCardList[^1];
        unusedCardList.RemoveAt(unusedCardList.Count - 1);
        return card;
    }

    //洗牌
    void Shuffle<T>(List<T> array)
    {
        int n = array.Count;

        for (int i = 0; i < n; i++)
        {

            int r = i + Random.Range(0, n - i);

            T t = array[r];

            array[r] = array[i];

            array[i] = t;

        }
    }
}
