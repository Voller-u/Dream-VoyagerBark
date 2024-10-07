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

    

    private void Update()
    {
        fightUnit?.OnUpdate();
    }

    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.None:
                break;
            case FightType.Init:
                fightUnit = new FightInit();
                break;
            case FightType.Player:
                fightUnit = new FightPlayer();
                break;
            case FightType.Enemy:
                fightUnit = new FightEnemy();
                break;
            case FightType.Win:
                fightUnit = new FightWIn();
                break;
            case FightType.Lose:
                fightUnit = new FightLose();
                break;
        }
    }
}
