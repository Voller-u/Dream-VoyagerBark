using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : BaseManager<RoleManager>
{

    /// <summary>
    /// ��ɫӵ�е����п��Ƽ���
    /// </summary>
    public List<CardBase> cardList = new List<CardBase>();

    public Role role;

    public void Init()
    {
        GameManager.Instance.RoleAddCard("AttackCard", 3);
    }

    
}
