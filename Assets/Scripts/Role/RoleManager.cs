using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class RoleManager : BaseManager<RoleManager>
{
    public static string path = Application.streamingAssetsPath + "/RoleInfo/RoleInfo";

    /// <summary>
    /// 角色拥有的所有卡牌集合
    /// </summary>
    public List<Card> cardList = new List<Card>();

    public Role role;
    public RoleInfo roleInfo = new();

    public void Init()
    {
        GameManager.Instance.RoleAddCard(new AttackCard(), 3);
        GameManager.Instance.RoleAddCard(new DefenceCard(), 3);
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
        Tools.SaveClass(roleInfo, path);
    }

    public void ReadRoleInfo()
    {
        try
        {
            roleInfo = Tools.ReadClass<RoleInfo>(path);
        }
        catch(FileNotFoundException)
        {
            //TODO 游戏文件不存在，重新开始游戏

        }

        role.CurHp = roleInfo.curHp;
        role.gold = roleInfo.gold;
        role.Gold = role.gold;

        cardList = roleInfo.cards;
    }
    
}
