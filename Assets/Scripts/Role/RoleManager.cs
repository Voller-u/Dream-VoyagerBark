using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : BaseManager<RoleManager>
{
    /// <summary>
    /// ��ɫӵ�е����п��Ƽ���
    /// </summary>
    public List<CardBase> cardList;

    

    public void Init()
    {
        cardList = new List<CardBase>();

        //��ӿ���
    }
}
