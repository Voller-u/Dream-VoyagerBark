using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class RoleManager : BaseManager<RoleManager>
{
    public static string path = Application.streamingAssetsPath + "/RoleInfo/RoleInfo";

    /// <summary>
    /// ��ɫӵ�е����п��Ƽ���
    /// </summary>
    public List<Card> cardList = new List<Card>();

    public Role role;
    public RoleInfo roleInfo = new();

    public void Init()
    {
        GameManager.Instance.RoleAddCard(new AttackCard(), 2);
        GameManager.Instance.RoleAddCard(new DefenceCard(), 2);
        GameManager.Instance.RoleAddCard(new SpeedUpCard(), 2);
        GameManager.Instance.RoleAddCard(new SweepCard(), 2);
        GameManager.Instance.RoleAddCard(new HeavyChopCard(), 2);
        GameManager.Instance.RoleAddCard(new SecondSleepCard(), 2);
        GameManager.Instance.RoleAddCard(new NightMareCard(), 2);

        EventManager.Instance.OnDestroySaveEvent += () => SaveRoleInfo();
        ReadRoleInfo();
    }

    public void ObtainGold(int num)
    {
        if(role != null)
            role.Gold += num;
    }

    public void SetRoleInfo()
    {
        roleInfo.curHp = role.CurHp;
        
        roleInfo.gold = role.Gold;
        roleInfo.cards = cardList;
    }

    public void SaveRoleInfo()
    {
        SetRoleInfo();
        Tools.SaveClass(roleInfo, path);
    }

    public void ReadRoleInfo()
    {
        try
        {
            roleInfo = Tools.ReadClass<RoleInfo>(path);
            role.CurHp = roleInfo.curHp;
            role.gold = roleInfo.gold;
            role.Gold = role.gold;

            cardList = roleInfo.cards;
        }
        catch(FileNotFoundException)
        {
            //TODO ��Ϸ�ļ������ڣ����¿�ʼ��Ϸ
            
        }

        
    }
    
}
