using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public class Parallel : BTNode
    {
        public override bool DoEvaluate()
        {
            return true;
        }

        public override void Tick()
        {
            foreach(BTNode child in childList)
            {
                child.Tick();
            }
        }
    }
}

