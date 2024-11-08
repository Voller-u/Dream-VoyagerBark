using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lucy : Role
{
    /// <summary>
    /// ����Ĺ����Ƶ�����
    /// </summary>
    private int atkNum;

    public int AtkNum
    {
        get => atkNum;

        set
        {
            atkNum = Mathf.Clamp(value, 0, int.MaxValue);
            if(atkNum >=8)
            {
                activeSkillButton.interactable = true;
            }
        }
    }

    private int sixAwnStarNum;

    public int SixAwnStarNum
    {
        get => sixAwnStarNum;
        set => sixAwnStarNum = value;
    }

    private int eightAwnStarNum;

    public int EightAwnStarNum
    {
        get => eightAwnStarNum;
        set => eightAwnStarNum = value;
    }

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


    public void OnCardPlay(Card card)
    {
        if(card is IAttackCard)
        {
            AtkNum++;
        }
    }

    public override void InvokeActiveSkill()
    {
        Debug.Log("�ͷ���������");
        AtkNum -= 8;
        if (AtkNum < 8) 
        {
            activeSkillButton.interactable = false;
        }
    }

}
