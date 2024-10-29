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
    HitRock,//����
    Boss
}

[Serializable]
public class MapNode
{
    public MapNodeType type;
    [HideInInspector]
    public List<MapNode> nexts;

    public bool active;
    public bool selected;

    public MapNode(MapNodeType type)
    {
        this.type = type;
        nexts = new List<MapNode>();
    }

}
