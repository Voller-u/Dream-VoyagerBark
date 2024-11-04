using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public struct Runner:IComparable<Runner>
{
    /// <summary>
    /// ��Ȧ����
    /// </summary>
    public Character chara;
    /// <summary>
    /// ʣ�µ�·��
    /// </summary>
    public int leftJourney;

    public Runner(Character ch, int lapShift) : this()
    {
        chara = ch;
        leftJourney = lapShift;
    }

    public int CompareTo(Runner other)
    {
        if(this.leftJourney == other.leftJourney)
        {
            if (chara is Role)
                return -1;
            else
                return 1;
        }
        
        return this.leftJourney.CompareTo(other.leftJourney);
    }
}

[Serializable]
public class RunWay:BaseManager<RunWay>
{
    [Header("һȦ��·��")]
    public int lapShift;

    public List<Runner> runners;

    public RunWay()
    {
        lapShift = 1000;
        runners = new List<Runner>();
    }

    /// <summary>
    /// ���ܵ��������ѡ��
    /// </summary>
    /// <param name="ch"></param>
    public void Add(Character ch)
    {
        runners.Add(new Runner(ch, lapShift));

        runners.Sort();
    }

    /// <summary>
    /// �л�����һ���ܵ��յ��ѡ��
    /// </summary>
    public void Switch()
    {
        //�����ǰ���ѡ�ָ����꣬Ӧ�ŵ����ȥ
        if (runners.Count >0)
        {
            var runner = runners[0];
            runner.leftJourney = lapShift;
            runners[0] = runner;
        }

        int time = int.MaxValue;
        for(int i=0;i<runners.Count;i++)
        {
            //�������ʱ��
            time = Mathf.Min(time, runners[i].leftJourney / runners[i].chara.spd);
        }
        for(int i = 0; i < runners.Count; i++)
        {
            var runner = runners[i];
            runner.leftJourney = Mathf.Clamp(runners[i].leftJourney - runners[i].chara.spd * time, 0, int.MaxValue);
            runners[i] = runner;
        }
        Print();
        runners.Sort();
    }
    

    public void Remove(Character ch)
    {
        for(int i=0;i<runners.Count;i++)
        {
            if (runners[i].chara == ch)
            {
                runners.RemoveAt(i);
                break;
            }
        }
    }

    //������
    public void Print()
    {
        StringBuilder s = new StringBuilder();
        for(int i=0;i<runners.Count; i++)
        {
            s.Append("name: " + runners[i].chara.name + "\n" + "left: " + runners[i].leftJourney +"\n\n" + "speed: " + runners[i].chara.spd);
        }
        Debug.Log(s.ToString());
    }
}
