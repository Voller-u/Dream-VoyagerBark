using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int spd;

    protected virtual void Start()
    {
        RunWay.Instance.Add(this);
    }

    protected virtual void OnDestroy()
    {
        RunWay.Instance.Remove(this);
    }


}
