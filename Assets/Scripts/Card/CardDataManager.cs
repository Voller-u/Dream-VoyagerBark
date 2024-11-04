using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataManager : BaseManager<CardDataManager>
{
    public Dictionary<string, string> cardTipDic = new Dictionary<string, string>()
    {
        { "AttackCard","对指定敌方单体造成（10+10%ATK）点伤害" },
        {"HeavyChopCard" ,"对指定敌方单体造成（30+20%ATK）点伤害"},
        {"SweepCard","对所有敌方造成（12+5%ATK）点伤害" },
        {"DefenceCard","对自身生成（5+20%DEF）点护盾（护盾在自己的下一回合开始时消失）" },
        {"SpeedUpCard","提升自身（10%基础速度+20）点速度，持续两回合" },
        {"SecondSleepCard" ,"将所有手牌放回抽牌堆，打乱抽牌堆，重新抽取等量的手牌"},
        {"NightMareCard","使自身受到10%当前生命的伤害，立刻解除自身当前所有负面效果" }
    };
}
