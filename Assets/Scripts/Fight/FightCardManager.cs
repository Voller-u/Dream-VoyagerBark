using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCardManager : BaseManager<FightCardManager>
{
    /// <summary>
    /// ս�����������ƶ���Ŀ��Ƽ���
    /// </summary>
    public List<CardBase> unusedCardList;
    /// <summary>
    /// ս�������������ƶ���Ŀ��Ƽ���
    /// </summary>
    public List<CardBase> usedCardList;
    /// <summary>
    /// ս�������б����ĵĵĿ��Ƽ���
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

    //ϴ��
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
