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

        RoleManager.Instance.role.InvokeBeginAction();
    }

    public override void OnUpdate()
    {
        
    }
}
