using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
    public class Action : BTNode
    {
        public UnityAction action;

        public void SetAction(UnityAction act)
        {
            action = act;
        }

        public override bool DoEvaluate()
        {
            return true;
        }

        public override void Tick()
        {
            action.Invoke();
        }
    }
}

