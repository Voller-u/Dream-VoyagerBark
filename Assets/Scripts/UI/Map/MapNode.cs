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
    /// 左结点（可能存在）
    /// </summary>
    public MapNode left;
    /// <summary>
    /// 右结点（可能存在）
    /// </summary>
    public MapNode right;

    public MapNode(MapNodeType type)
    {
        this.type = type;
    }

}
