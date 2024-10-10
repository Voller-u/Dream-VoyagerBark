using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum FightType
{
    None,
    Init,
    Player,
    Enemy,
    Win,
    Lose
}

public class FightManager : MonoBehaviour
{
    public static FightManager Instance;

    public FightUnit fightUnit;


    private void Awake()
    {
        Instance = this;
        
    }

    private void Start()
    {
        UIManager.Instance.ShowUI<FightUI>("FightUI");
        ChangeType(FightType.Init);
        ChangeType(FightType.Player);

    }


    private void Update()
    {
        fightUnit?.OnUpdate();
    }

    /// <summary>
    /// 切换到指定类型的回合
    /// </summary>
    /// <param name="type"></param>

    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.Init:
                fightUnit = new FightInit();
                Debug.Log("关卡初始化");
                break;
            case FightType.Player:
                fightUnit = new FightPlayer();
                Debug.Log("玩家回合");
                break;
            case FightType.Enemy:
                fightUnit = new FightEnemy();
                Debug.Log("敌人回合");
                break;
            case FightType.Win:
                fightUnit = new FightWIn();
                Debug.Log("胜利");
                break;
            case FightType.Lose:
                fightUnit = new FightLose();
                Debug.Log("失败");
                break;
        }
        fightUnit.Init();
    }

    /// <summary>
    /// 切换到下一回合
    /// </summary>
    public void ChangeType()
    {
        //TODO
        Debug.Log("计算速度，切换到下一回合");

        if(fightUnit is FightPlayer)
        {
            ChangeType(FightType.Enemy);
        }
        else if(fightUnit is FightEnemy)
        {
            ChangeType(FightType.Player);
        }
    }
}
