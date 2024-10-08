using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int atk;
    public int def;
    public int spd;
    public int maxHp;
    public int curHp;
    public int shield;

    protected virtual void Start()
    {
        curHp = maxHp;
    }

    public virtual void Hurt(int atk)
    {
        int rem = shield - atk;
        if(rem > 0)
        {
            curHp = Mathf.Clamp(curHp - rem,0, maxHp);
        }
        else
        {
            shield -= atk;
        }
    }

}
