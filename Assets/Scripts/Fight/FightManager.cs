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
    /// �л���ָ�����͵Ļغ�
    /// </summary>
    /// <param name="type"></param>

    public void ChangeType(FightType type)
    {
        switch (type)
        {
            case FightType.Init:
                fightUnit = new FightInit();
                Debug.Log("�ؿ���ʼ��");
                break;
            case FightType.Player:
                fightUnit = new FightPlayer();
                Debug.Log("��һغ�");
                break;
            case FightType.Enemy:
                fightUnit = new FightEnemy();
                Debug.Log("���˻غ�");
                break;
            case FightType.Win:
                fightUnit = new FightWIn();
                Debug.Log("ʤ��");
                break;
            case FightType.Lose:
                fightUnit = new FightLose();
                Debug.Log("ʧ��");
                break;
        }
        fightUnit.Init();
    }

    /// <summary>
    /// �л�����һ�غ�
    /// </summary>
    public void ChangeType()
    {
        //TODO
        Debug.Log("�����ٶȣ��л�����һ�غ�");

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
