using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public int spd;

    public RoundAction roundBeginAction;
    public RoundAction roundEndAction;

    public ShieldList<Shield> shield = new();
    public List<Buff> buffs = new();
    public List<PermanantBuff> permanantBuffs = new();


    protected virtual void Start()
    {
        RunWay.Instance.Add(this);
        roundBeginAction += () =>
        {
            while(shield.Count > 0 && shield[^1].num <= 1)
            {
                shield.RemoveAt(shield.Count - 1 );
            }
        };
        roundEndAction += () =>
        {
            for(int i = 0; i < buffs.Count;)
            {
                if (buffs[i].round <= 1)
                {
                    buffs[i].RemoveBuff?.Invoke();
                    buffs.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        };
    }

    protected virtual void OnDestroy()
    {
        RunWay.Instance.Remove(this);
    }


    public void InvokeBeginAction()
    {
        roundBeginAction?.Invoke();
        

    }

    public void InvokeEndAction()
    {
        roundEndAction?.Invoke();
        
    }

    public void AddShield(Shield item)
    {
        shield.Add(item);
    }

    public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
        buff.AddBuff?.Invoke();
    }

}

public class PermanantBuff
{

}
public class Buff
{
    public UnityAction AddBuff;
    public UnityAction RemoveBuff;
    public int round;

    public Buff(UnityAction addBuff, UnityAction removeBuff, int round)
    {
        AddBuff = addBuff;
        RemoveBuff = removeBuff;
        this.round = round;
    }
}