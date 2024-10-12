using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum MapNodeType
{
    Random,
    Reflux,
    Rapids,
    Monster,
    InfernalMob,
    Island,
    Bonus,
    Merchant,
    Boss
}

[Serializable]
public class MapNode
{
    public MapNodeType type;

    /// <summary>
    /// ���㣨���ܴ��ڣ�
    /// </summary>
    public MapNode left;
    /// <summary>
    /// �ҽ�㣨���ܴ��ڣ�
    /// </summary>
    public MapNode right;

    public MapNode(MapNodeType type)
    {
        this.type = type;
    }

}
