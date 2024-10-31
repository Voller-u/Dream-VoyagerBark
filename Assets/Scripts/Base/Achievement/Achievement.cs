using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Achievement
{
    [Header("�ɾ�����")]
    public string title;
    [Header("�ɾ�����")]
    public string description;
    [Header("Ŀ������")]
    public int targetNum;
    [Header("��ǰ����")]
    public int curNum;

    public Achievement()
    {

    }
    public Achievement(string title, string description, int targetNum, int curNum)
    {
        this.title = title;
        this.description = description;
        this.targetNum = targetNum;
        this.curNum = curNum;
    }

    public virtual void AchievementListener()
    {

    }
    public virtual void AddNum(int num)
    {
        curNum = Mathf.Clamp(curNum + num, 0, targetNum);
        if(curNum >= targetNum)
        {
            Completed();
        }
    }

    public virtual void Completed()
    {
        EventManager.Instance.OnAchievementCompleted(this);
    }
}

[Serializable]
public class AchievementCenter
{
    public List<Achievement> achievementList;
}

[Serializable]
public class GoldAchievement : Achievement
{

    public GoldAchievement(string title, string description, int targetNum, int curNum)
    {
        this.title = title;
        this.description = description;
        this.targetNum = targetNum;
        this.curNum = curNum;
    }

    public override void AchievementListener()
    {
        EventManager.Instance.OnGoldObtainEvent += AddNum;
    }

}