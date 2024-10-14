using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
    public class Action : BTNode
    {
        public Action(string name) : base(name) { }
        public UnityAction action;



        public void SetAction(UnityAction act)
        {
            action = act;
        }


        public override void Tick()
        {
            action.Invoke();
        }
    }
}

