using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BTNode
{
    public string name;
    public List<BTNode> childList;
    /// <summary>
    /// 节点准入条件
    /// </summary>
    public Func<bool> precondition;
    /// <summary>
    /// 是否激活
    /// </summary>
    public bool activated;

    public BTNode(string name)
    {
        this.name = name;
        childList = new List<BTNode>();
    }

    /// <summary>
    /// 激活节点
    /// </summary>
    public virtual void Activate()
    {

    }

    /// <summary>
    /// 个性化检查
    /// </summary>
    public virtual bool DoEvaluate()
    {
        if(precondition != null)
        {
            return precondition.Invoke();
        }
        return true;
    }

    /// <summary>
    /// 节点执行
    /// </summary>
    public virtual void Tick()
    {

    }

    public virtual BTNode AddChild(BTNode node)
    {
        childList.Add(node);

        return node;
    }

    public virtual void RemoveChild(BTNode node)
    {
        childList.Remove(node);
    }

    public virtual BTNode FindNode(string name)
    {
        foreach(BTNode node in childList)
        {
            if (node.name == name)
            {
                return node;
            }
        }
        return null;
    }
}
