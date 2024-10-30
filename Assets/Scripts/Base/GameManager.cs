using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Internal;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    

    private void Awake()
    {
        Instance = this;
        RoleManager.Instance.Init();
        
    }

    private void Start()
    {
        UIManager.Instance.ShowUI<PropertyUI>("PropertyUI");
        UIManager.Instance.ShowUI<MapUI>("MapUI");
    }

    public void RoleAddCard(string cardName, int num = 1)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject obj = Instantiate(Resources.Load("Cards/" + cardName) as GameObject);
            obj.SetActive(false);
            CardBase card = obj.GetComponent<CardBase>();
            RoleManager.Instance.cardList.Add(card);
        }
    }

    public void MapEventHandler(MapNodeType type)
    {
        switch (type)
        {
            case MapNodeType.Random:
                RandomEventHandler();
                break;
            case MapNodeType.Monster:
                MonsterEventHandler();
                break;
            case MapNodeType.InfernalMob:
                InfernalMobEventHandler();
                break;
            case MapNodeType.Island:
                IslandEventHandler();
                break;
            case MapNodeType.Bonus:
                BonusEventHandler();    
                break;
            case MapNodeType.Merchant:
                MerchantEventHandler();
                break;
            case MapNodeType.Reflux:
                RefluxEventHandler();
                break;
            case MapNodeType.Rapids:
                RapidsEventHandler();
                break;
            case MapNodeType.HitRock:
                HitRockHandler();
                break;
            case MapNodeType.Boss:
                BossEventHandler();
                break;
        }
    }

    void RandomEventHandler()
    {
        MapNodeType[] randomEvents = {MapNodeType.Reflux,MapNodeType.Rapids,
            MapNodeType.HitRock,MapNodeType.Monster ,MapNodeType.InfernalMob,
            MapNodeType.Bonus,MapNodeType.Merchant,MapNodeType.Island};
        //                                      ����    ����   ����   ����    ��Ӣ    ����  ����   ��
        List<float> weight = new List<float> { 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.1f, 0.1f, 0.05f };
        int i = Tools.GetRandomWeightedIndex(weight);
        MapEventHandler(randomEvents[i]);
    }

    void MonsterEventHandler()
    {
        Debug.Log("��������");
        FightManager.Instance.Init();
    }

    void InfernalMobEventHandler()
    {
        Debug.Log("������Ӣ��");
        FightManager.Instance.Init();
    }

    void IslandEventHandler()
    {
        //TODO������Ϣ�¼�
        Debug.Log("������Ϣ");
        FightManager.Instance.Init();
    }

    void BonusEventHandler()
    {
        Debug.Log("��������");
        FightManager.Instance.Init();
    }

    void MerchantEventHandler()
    {
        Debug.Log("��������");
        FightManager.Instance.Init();
    }

    void RefluxEventHandler()
    {
        Debug.Log("��������");
        FightManager.Instance.Init();
    }

    void RapidsEventHandler()
    {
        Debug.Log("��������");
        FightManager.Instance.Init();
    }

    void HitRockHandler()
    {
        Debug.Log("��������");
        FightManager.Instance.Init();
    }

    void BossEventHandler()
    {
        Debug.Log("����bossս");
        FightManager.Instance.Init();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            MapUI mapUI = UIManager.Instance.GetUI<MapUI>("MapUI");
            Tools.SaveClass<MapInfo>(mapUI.mapInfo,mapUI.path);
            Debug.Log("�����ͼ�ɹ�");
        }
    }

    public Coroutine GameStartCoroutine(IEnumerator routine)
    {
        return StartCoroutine(routine);
    }

    public Coroutine GameStartCoroutine(string methodName, [DefaultValue("null")] object value)
    {
        return StartCoroutine(methodName, value);
    }

    public Coroutine GameStartCoroutine(string methodName)
    {
        return StartCoroutine(methodName);
    }
}
