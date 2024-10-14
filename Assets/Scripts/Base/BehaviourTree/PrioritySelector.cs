using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public class PrioritySelector : BTNode
    {
        public PrioritySelector(string name) : base(name) { }
        public override bool DoEvaluate()
        {
            foreach (BTNode child in childList)
            {
                if (child.DoEvaluate())
                {
                    return true;
                }
            }
            return false;
        }

        public override void Tick()
        {
            foreach (BTNode child in childList)
            {
                if (child.DoEvaluate())
                {
                    child.Tick();
                }
            }
        }
    }

}

