using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //                                      回流    湍流   触礁   怪物    精英    宝箱  商人   岛
        List<float> weight = new List<float> { 0.15f, 0.15f, 0.15f, 0.15f, 0.15f, 0.1f, 0.1f, 0.05f };
        int i = Tools.GetRandomWeightedIndex(weight);
        MapEventHandler(randomEvents[i]);
    }

    void MonsterEventHandler()
    {
        Debug.Log("触发怪物");
        FightManager.Instance.Init();
    }

    void InfernalMobEventHandler()
    {
        Debug.Log("触发精英怪");
        FightManager.Instance.Init();
    }

    void IslandEventHandler()
    {
        //TODO处理休息事件
        Debug.Log("触发休息");
    }

    void BonusEventHandler()
    {
        Debug.Log("触发宝箱");
    }

    void MerchantEventHandler()
    {
        Debug.Log("触发商人");
    }

    void RefluxEventHandler()
    {
        Debug.Log("触发回流");
    }

    void RapidsEventHandler()
    {
        Debug.Log("触发湍流");
    }

    void HitRockHandler()
    {
        Debug.Log("触发触礁");
    }

    void BossEventHandler()
    {
        Debug.Log("触发boss战");
    }
}
