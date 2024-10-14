using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BT
{
    public class Conditional : BTNode
    {
        public Conditional(string name) : base(name) { }
        public Func<bool> condition;

        public void SetCondition(Func<bool> condition)
        {
            this.condition = condition;
        }

        public override bool DoEvaluate()
        {
            return condition.Invoke();
        }


    }
}


