using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataManager : BaseManager<CardDataManager>
{
    public Dictionary<string, string> cardTipDic = new Dictionary<string, string>()
    {
        { "AttackCard","��ָ���з�������ɣ�10+10%ATK�����˺�" },
        {"HeavyChopCard" ,"��ָ���з�������ɣ�30+20%ATK�����˺�"},
        {"SweepCard","�����ез���ɣ�12+5%ATK�����˺�" },
        {"DefenceCard","���������ɣ�5+20%DEF���㻤�ܣ��������Լ�����һ�غϿ�ʼʱ��ʧ��" },
        {"SpeedUpCard","��������10%�����ٶ�+20�����ٶȣ��������غ�" },
        {"SecondSleepCard" ,"���������ƷŻس��ƶѣ����ҳ��ƶѣ����³�ȡ����������"},
        {"NightMareCard","ʹ�����ܵ�10%��ǰ�������˺������̽������ǰ���и���Ч��" }
    };
}
