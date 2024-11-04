using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class MapInfo
{
    [Header("����")]
    public int levelNum = 12;

    public int curLevelNum = 0;

    [HideInInspector]
    public List<List<MapNode>> nodes;

    public List<MapNode> selectedNodes = new List<MapNode>();

    /// <summary>
    /// ��ǰ���ڵĽ��
    /// </summary>
    public MapNode curMapNode;

    private List<float> weightOfMapNode;

    public void InitMap()
    {


        GenerateMap();
        //Print();
    }

    public void GenerateMap()
    {
        Init();
        AddNode();
        AddConnection();
    }

    void Init()
    {
        nodes = new List<List<MapNode>>(levelNum);
        for (int i = 0; i < levelNum; i++)
        {
            nodes.Add(new List<MapNode>());
        }

        weightOfMapNode = new List<float>
        {
            0.25f,0.3f,0.15f,0.1f,0.1f,0.1f
        };
    }

    /// <summary>
    /// ������
    /// </summary>
    void AddNode()
    {
        //ÿһ���������
        int x = UnityEngine.Random.Range(3, 6);
        //��ӵ�һ����
        for (int i = 0; i < x; i++)
        {
            MapNode firstLevelNode = new MapNode(MapNodeType.Monster);
            firstLevelNode.active = true;
            nodes[0].Add(firstLevelNode);
        }
            
        //��ӵڶ��㵽��������
        for(int i = 1;i < 6;i++)
        {
            int y = UnityEngine.Random.Range(3, 6);
            
            for(int j = 0;j < y;j++)
            {
                int nodeType = Tools.GetRandomWeightedIndex(weightOfMapNode);
                nodes[i].Add(new MapNode((MapNodeType)nodeType));
            }
                
        }

        //��ӵ��߲���
        x = UnityEngine.Random.Range(3, 6);
        for (int i = 0; i < x; i++)
            nodes[6].Add(new MapNode(MapNodeType.Bonus));

        //��ӵڰ˵���ʮ����
        for (int i = 7; i < 10; i++)
        {
            int y = UnityEngine.Random.Range(3, 6);

            for (int j = 0; j < y; j++)
            {
                int nodeType = Tools.GetRandomWeightedIndex(weightOfMapNode);
                nodes[i].Add(new MapNode((MapNodeType)nodeType));
            }

        }

        //��ӵ�ʮһ����
        x = UnityEngine.Random.Range(3, 6);
        for (int i = 0; i < x; i++)
            nodes[10].Add(new MapNode(MapNodeType.Island));

        //��ӵ�ʮ������
        nodes[11].Add(new MapNode(MapNodeType.Boss));
    }

    /// <summary>
    /// �����֮���������
    /// </summary>
    void AddConnection()
    {
        //·��Ҫ��

        //4.ÿ��·���������������Ϣ������bossǰ��
        //5.����������������Ϣ�����䡢���ˡ���Ӣ��
        //6.ÿ��·�������ٳ�һ������
        //7.ÿ��·�������ٳ�һ����Ӣ
        for (int i = 0; i < 11; i++) 
        {
            for(int j = 0; j < nodes[i].Count;j++)
            {
                AddConnection(nodes[i][j], i, j);
            }
        }
    }

    /// <summary>
    /// ��ĳ�������������Ľ�������
    /// </summary>
    /// <param name="node">�ý��</param>
    /// <param name="level">�ý�����ڵĲ�</param>
    /// <param name="col">�ý�������ڲ����</param>
    void AddConnection(MapNode node,int level,int col)
    {
        foreach (MapNode nextNode in nodes[level+1])
        {
            if(!CheckNotValidNode(node,nextNode))
            {
                node.nexts.Add(nextNode);
            }
        }
        //�ٴ����������������
        Tools.Shuffle(node.nexts);
        while(node.nexts.Count > 2)
        {
            node.nexts.RemoveAt(node.nexts.Count - 1);
        }


        //���û����һ����㣬�ý����Ч
        if(node.nexts.Count == 0)
        {
            node.type = MapNodeType.Monster;
            AddConnection(node, level, col);
        }
        
    }

    bool CheckNotValidNode(MapNode node,MapNode nextNode)
    {
        if(node.type == nextNode.type)
        {
            return node.type == MapNodeType.Island || node.type == MapNodeType.Bonus
                    || node.type == MapNodeType.Merchant || node.type == MapNodeType.InfernalMob;
        }
        return false;
    }


    //������
    public void Print()
    {
        StringBuilder s = new StringBuilder();
        for(int i=0;i<nodes.Count;i++)
        {
            for(int j = 0; j < nodes[i].Count;j++)
            {
                s.Append(nodes[i][j].type.ToString() + " ");
            }
            s.AppendLine();
        }

        Debug.Log(s.ToString());

        s.Clear();
        s.AppendLine().AppendLine();
        for (int i = 0; i < nodes.Count; i++)
        {
            for (int j = 0; j < nodes[i].Count; j++)
            {
                foreach(MapNode m in nodes[i][j].nexts)
                {
                    s.Append(m.type.ToString() + " ");
                }
                s.AppendLine();
            }
            s.AppendLine();
        }
        Debug.Log(s.ToString() );
        
    }

    public void RevertNode( MapNode node )
    {
        for(int i=0;i<nodes.Count; i++)
        {
            for(int j = 0; j < nodes[i].Count;j++)
            {
                if (nodes[i][j] == node)
                {
                    nodes[i][j].selected = false;
                    nodes[i][j].active = true;
                }
            }
        }
    }
}
