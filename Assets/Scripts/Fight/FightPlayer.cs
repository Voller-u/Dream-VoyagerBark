using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer : FightUnit
{
    public override void Init()
    {
        Debug.Log("��һغ�");
        UIManager.Instance.ShowTip("��һغ�", Color.black, delegate ()
        {
            //����
            Debug.Log("���ƶ��г���");
        });
    }

    public override void OnUpdate()
    {
        
    }
}
