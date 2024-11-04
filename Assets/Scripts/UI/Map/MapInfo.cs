using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
public class MapInfo
{
    [Header("层数")]
    public int levelNum = 12;

    public int curLevelNum = 0;

    [HideInInspector]
    public List<List<MapNode>> nodes;

    public List<MapNode> selectedNodes = new List<MapNode>();

    /// <summary>
    /// 当前处于的结点
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
    /// 加入结点
    /// </summary>
    void AddNode()
    {
        //每一层结点的数量
        int x = UnityEngine.Random.Range(3, 6);
        //添加第一层结点
        for (int i = 0; i < x; i++)
        {
            MapNode firstLevelNode = new MapNode(MapNodeType.Monster);
            firstLevelNode.active = true;
            nodes[0].Add(firstLevelNode);
        }
            
        //添加第二层到第六层结点
        for(int i = 1;i < 6;i++)
        {
            int y = UnityEngine.Random.Range(3, 6);
            
            for(int j = 0;j < y;j++)
            {
                int nodeType = Tools.GetRandomWeightedIndex(weightOfMapNode);
                nodes[i].Add(new MapNode((MapNodeType)nodeType));
            }
                
        }

        //添加第七层结点
        x = UnityEngine.Random.Range(3, 6);
        for (int i = 0; i < x; i++)
            nodes[6].Add(new MapNode(MapNodeType.Bonus));

        //添加第八到第十层结点
        for (int i = 7; i < 10; i++)
        {
            int y = UnityEngine.Random.Range(3, 6);

            for (int j = 0; j < y; j++)
            {
                int nodeType = Tools.GetRandomWeightedIndex(weightOfMapNode);
                nodes[i].Add(new MapNode((MapNodeType)nodeType));
            }

        }

        //添加第十一层结点
        x = UnityEngine.Random.Range(3, 6);
        for (int i = 0; i < x; i++)
            nodes[10].Add(new MapNode(MapNodeType.Island));

        //添加第十二层结点
        nodes[11].Add(new MapNode(MapNodeType.Boss));
    }

    /// <summary>
    /// 给结点之间添加连线
    /// </summary>
    void AddConnection()
    {
        //路线要求：

        //4.每条路线上最多有三个休息（包括boss前）
        //5.不能连续出两个休息、宝箱、商人、精英怪
        //6.每条路线上至少出一个商人
        //7.每条路线上至少出一个精英
        for (int i = 0; i < 11; i++) 
        {
            for(int j = 0; j < nodes[i].Count;j++)
            {
                AddConnection(nodes[i][j], i, j);
            }
        }
    }

    /// <summary>
    /// 给某个结点添加与后面的结点的连线
    /// </summary>
    /// <param name="node">该结点</param>
    /// <param name="level">该结点所在的层</param>
    /// <param name="col">该结点在所在层的列</param>
    void AddConnection(MapNode node,int level,int col)
    {
        foreach (MapNode nextNode in nodes[level+1])
        {
            if(!CheckNotValidNode(node,nextNode))
            {
                node.nexts.Add(nextNode);
            }
        }
        //再从里面挑出随机个数
        Tools.Shuffle(node.nexts);
        while(node.nexts.Count > 2)
        {
            node.nexts.RemoveAt(node.nexts.Count - 1);
        }


        //如果没有下一个结点，该结点无效
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


    //测试用
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
