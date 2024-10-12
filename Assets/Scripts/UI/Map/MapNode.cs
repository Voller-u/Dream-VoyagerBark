using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum MapNodeType
{
    Random,//����¼�
    Monster,//����
    InfernalMob,//��Ӣ��
    Island,//��
    Bonus,//����
    Merchant,//����
    Reflux,//����
    Rapids,//����
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
