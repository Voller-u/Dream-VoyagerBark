using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer : FightUnit
{


    public override void Init()
    {
        //UIManager.Instance.ShowTip("��һغ�", Color.black, delegate ()
        //{
            
        //});
        //����
        Debug.Log("���ƶ��г���");
        FightCardManager.Instance.AddCard();
        UIManager.Instance.SetInteractableUI("FightUI", true);
    }

    public override void OnUpdate()
    {
        
    }
}
