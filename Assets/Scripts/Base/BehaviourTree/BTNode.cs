using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BTNode
{
    public string name;
    public List<BTNode> childList;
    /// <summary>
    /// �ڵ�׼������
    /// </summary>
    public bool precondition;
    /// <summary>
    /// �Ƿ񼤻�
    /// </summary>
    public bool activated;

    /// <summary>
    /// ����ڵ�
    /// </summary>
    public virtual void Activate()
    {

    }

    /// <summary>
    /// ���Ի����
    /// </summary>
    public virtual bool DoEvaluate()
    {
        return false;
    }

    /// <summary>
    /// �ڵ�ִ��
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
