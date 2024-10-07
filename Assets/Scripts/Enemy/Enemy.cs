using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int atk;
    protected int def;
    protected int spd;
    protected int maxHp;
    protected int curHp;
    protected int shield;

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
