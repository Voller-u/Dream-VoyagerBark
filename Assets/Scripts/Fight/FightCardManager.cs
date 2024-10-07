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

    /// <summary>
    /// ���Ƽ���
    /// </summary>
    public List<CardBase> cardList;

    public Transform pocket; 


    public void Init()
    {
        unusedCardList = new List<CardBase>();
        usedCardList = new List<CardBase>();
        exhaustedCardList = new List<CardBase>();
        cardList = new List<CardBase>();

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

    //ϴ��
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

    void AddCard()
    {
        GameObject obj = DrawCard();
        CardBase card = obj.GetComponent<CardBase>();
        cardList.Add(card);
        obj.transform.SetParent(pocket,false);
        obj.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RoleManager.Instance.Init();
            Init();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCard();
        }
    }

    public void RoleAddCard(string cardName,int num = 1)
    {
        for(int i=0;i<num;i++)
        {
            GameObject obj = Instantiate(Resources.Load("Cards/" + cardName) as GameObject);
            obj.SetActive(false);
            CardBase card = obj.GetComponent<CardBase>();
            RoleManager.Instance.cardList.Add(card);
        }
    }

}
