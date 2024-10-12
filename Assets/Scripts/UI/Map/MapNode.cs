using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum MapNodeType
{
    Random,//随机事件
    Monster,//怪物
    InfernalMob,//精英怪
    Island,//岛
    Bonus,//宝箱
    Merchant,//商人
    Reflux,//回流
    Rapids,//湍流
    Boss
}

[Serializable]
public class MapNode
{
    public MapNodeType type;

    public List<MapNode> nexts;

    public MapNode(MapNodeType type)
    {
        this.type = type;
        nexts = new List<MapNode>();
    }

}
