using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public int spdBase;
    public int spd;

    public RoundAction roundBeginAction;
    public RoundAction roundEndAction;

    public ShieldList<Shield> shield = new();

    public Text shieldNum;

    public List<Buff> buffs = new();
    public List<PermanantBuff> permanantBuffs = new();

    protected virtual void Awake()
    {
        RunWay.Instance.Add(this);
        Debug.Log("¼ÓÈëÅÜµÀ:" + gameObject.name);
    }

    protected virtual void Start()
    {
        
        spd = spdBase;
        roundBeginAction += () =>
        {
            for(int i=0;i<shield.Count;i++)
            {
                shield[i].round--;
            }
            while(shield.Count > 0 && shield[^1].num <= 0)
            {
                shield.RemoveAt(shield.Count - 1 );
            }
        };
        roundEndAction += () =>
        {
            for(int i = 0; i < buffs.Count;)
            {
                buffs[i].round--;
                if (buffs[i].round <= 0)
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

    private void Update()
    {
        int cnt = 0;
        for(int i=0;i<shield.Count;i++)
        {
            cnt += shield[i].num;
        }
        shieldNum.text = cnt.ToString();
    }

}

public class PermanantBuff
{

}
[Serializable]
public class Buff
{
    public UnityAction AddBuff;
    public UnityAction RemoveBuff;
    public int round;
    public bool isDebuff;

    public Buff(UnityAction addBuff, UnityAction removeBuff, int round,bool _isDebuff = false)
    {
        AddBuff = addBuff;
        RemoveBuff = removeBuff;
        this.round = round;
        isDebuff = _isDebuff;
    }
}