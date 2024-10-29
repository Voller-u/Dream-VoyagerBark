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
        

    }

    /// <summary>
    /// ս����������ʼ��
    /// </summary>
    public void Init()
    {
        UIManager.Instance.ShowUI<FightUI>("FightUI");
        UIManager.Instance.HideUI("MapUI");

        //TODO ��̬���ع���
        EnemyIncubator.Instance.IncubateEnemy("Slime", 0);
        EnemyIncubator.Instance.IncubateEnemy("Slime", 2);

        ChangeType(FightType.Init);
        ChangeType();
    }



    private void Update()
    {
        fightUnit?.OnUpdate();

        if(Input.GetKeyDown(KeyCode.D))
        {
            RunWay.Instance.Print();
        }
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
        //Debug.Log("�����ٶȣ��л�����һ�غ�");

        RunWay.Instance.Switch();
        if(RunWay.Instance.runners.Count > 0)
        {
            Character actor = RunWay.Instance.runners[0].chara;
            if(actor is Role)
            {
                ChangeType(FightType.Player);
            }
            else if(actor is Enemy)
            {
                EnemyManager.Instance.actEnemy = actor as Enemy;
                ChangeType(FightType.Enemy);
                
            }
        }
    }
}
