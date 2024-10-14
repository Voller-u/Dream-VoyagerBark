using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public class Sequence : BTNode
    {
        public Sequence(string name) : base(name) { }
        public override bool DoEvaluate()
        {
            foreach (BTNode child in childList)
            {
                if (!child.DoEvaluate())
                {
                    return false;
                }
            }
            return true;
        }

        public override void Tick()
        {
            if (DoEvaluate())
            {
                foreach (BTNode child in childList)
                {
                    child.Tick();
                }
            }
        }
    }

}

