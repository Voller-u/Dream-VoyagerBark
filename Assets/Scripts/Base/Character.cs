using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int spd;

    public RoundAction roundBeginAction;
    public RoundAction roundEndAction;

    protected Dictionary<RoundAction, int> beginActionDic = new Dictionary<RoundAction, int>();
    protected Dictionary<RoundAction, int> endActionDic = new Dictionary<RoundAction, int>();

    protected virtual void Start()
    {
        RunWay.Instance.Add(this);
    }

    protected virtual void OnDestroy()
    {
        RunWay.Instance.Remove(this);
    }

    public void AddBeginAction(RoundAction action,int round)
    {
        beginActionDic[action] = round;
        roundBeginAction += action;
    }

    public void AddEndAction(RoundAction action,int round)
    {
        endActionDic[action] = round;
        roundEndAction += action;
    }

    public void InvokeBeginAction()
    {
        roundBeginAction?.Invoke();
        List<RoundAction> actions = new List<RoundAction>();
        foreach(RoundAction action in  beginActionDic.Keys)
        {
            if (beginActionDic[action] ==1)
            {
                actions.Add(action);
            }
        }

        for(int i=0;i<actions.Count;i++)
        {
            beginActionDic.Remove(actions[i]);
            roundBeginAction -= actions[i];
        }

    }

    public void InvokeEndAction()
    {
        roundEndAction?.Invoke();
        List<RoundAction> actions = new List<RoundAction>();
        foreach (RoundAction action in endActionDic.Keys)
        {
            if (endActionDic[action] == 1)
            {
                actions.Add(action);
            }
        }

        for (int i = 0; i < actions.Count; i++)
        {
            endActionDic.Remove(actions[i]);
            roundEndAction -= actions[i];
        }
    }

}
