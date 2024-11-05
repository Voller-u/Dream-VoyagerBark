using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lucy : Role
{
    /// <summary>
    /// 打出的攻击牌的数量
    /// </summary>
    public int atkNum;

    protected override void Start()
    {
        base.Start();
        //注册监听卡牌打出事件
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
