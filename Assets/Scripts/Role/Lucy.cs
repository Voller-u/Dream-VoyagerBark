using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lucy : Role
{
    /// <summary>
    /// ����Ĺ����Ƶ�����
    /// </summary>
    public int atkNum;

    protected override void Start()
    {
        base.Start();
        //ע��������ƴ���¼�
        EventManager.Instance.OnCardPlayEvent += OnCardPlay;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        EventManager.Instance.OnCardPlayEvent -= OnCardPlay;
    }

    public void ProactiveSkill()
    {

    }

    public void OnCardPlay(Card card)
    {
        if(card is IAttackCard)
        {
            atkNum++;
        }
    }

}
