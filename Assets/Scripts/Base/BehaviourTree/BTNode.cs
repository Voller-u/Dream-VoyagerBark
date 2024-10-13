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
    public bool precondition;
    /// <summary>
    /// 是否激活
    /// </summary>
    public bool activated;

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
        return false;
    }

    /// <summary>
    /// 节点执行
    /// </summary>
    public virtual void Tick()
    {

    }

    public virtual void AddChild(BTNode node)
    {
        childList.Add(node);
    }

    public virtual void RemoveChild(BTNode node)
    {
        childList.Remove(node);
    }
}
