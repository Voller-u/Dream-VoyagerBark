using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 加速
/// </summary>
[Serializable]
public class SpeedUpCard : Card
{
    public float spd = 0.1f;

    public override void Effect()
    {
        Role role = RoleManager.Instance.role;

        int calRes = (int)(spd * role.spdBase + 20);

        Buff buff = new Buff(() => role.spd += calRes, () => role.spd -= calRes, 2);
        role.AddBuff(buff);
    }
}
/// <summary>
/// 回笼觉
/// </summary>
[Serializable]
public class SecondSleepCard:Card
{
    public override void Effect()
    {
        int num = 0;
        while (FightCardManager.Instance.cardList.Count > 0) 
        {
            num++;
            FightCardManager.Instance.unusedCardList.Add(FightCardManager.Instance.cardList[0].card);
            CardPool.Instance.HideCard(FightCardManager.Instance.cardList[0]);
            FightCardManager.Instance.cardList.RemoveAt(0);
        }
        Tools.Shuffle(FightCardManager.Instance.unusedCardList);
        FightCardManager.Instance.AddCard(num);
    }
}
/// <summary>
/// 梦引
/// </summary>
[Serializable]
public class DreamGuideCard : Card
{

}

/// <summary>
/// 美梦
/// </summary>
[Serializable]
public class SweetDreamCard : Card
{
    public override void Effect()
    {
        base.Effect();
    }
}

/// <summary>
/// 噩梦
/// </summary>
[Serializable]
public class NightMareCard : Card
{
    public override void Effect()
    {
        RoleManager.Instance.role.CurHp -= Mathf.Clamp((int)(RoleManager.Instance.role.CurHp * 0.1f),1,RoleManager.Instance.role.maxHp -1 );
        for(int i=RoleManager.Instance.role.buffs.Count-1;i>=0 ;i--)
        {
            if (RoleManager.Instance.role.buffs[i].isDebuff)
            {
                RoleManager.Instance.role.buffs.RemoveAt(i);
            }
        }
    }
}