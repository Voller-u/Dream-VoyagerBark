using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CardBase:MonoBehaviour
{
    //public CardData data;

    public virtual void Effect()
    {

    }

    public virtual void Effect(Role role)
    {

    }
    public virtual void Effect(Enemy enemy) 
    {

    }
}
