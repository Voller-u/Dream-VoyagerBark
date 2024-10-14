using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BT 
{
    public class Random : BTNode
    {
        public Random(string name) : base(name) { }
        public override bool DoEvaluate()
        {
            foreach (BTNode child in childList)
            {
                if (child.DoEvaluate())
                { return true; }
            }
            return false;
        }

        public override void Tick()
        {
            List<int> childs = new List<int>();

            for (int i = 0; i < childList.Count; i++)
            {
                if (childList[i].DoEvaluate())
                {
                    childs.Add(i);
                }
            }

            int randomAction = UnityEngine.Random.Range(0, childs.Count);
            childList[childs[randomAction]].Tick();
        }

        public override BTNode AddChild(BTNode node)
        {
            if(!(node is BT.Action))
            {
                Debug.LogError("不允许将Action以外的结点作为Random结点的子节点");
                return null;
            }
            childList.Add(node);
            return node;
        }
    }
}



