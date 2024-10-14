using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT
{
    public class Parallel : BTNode
    {
        public Parallel(string name) : base(name) { }


        public override void Tick()
        {
            foreach(BTNode child in childList)
            {
                child.Tick();
            }
        }
    }
}

