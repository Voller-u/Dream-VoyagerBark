using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MapUI : UIBase
{
    [Header("层数")]
    public int levelNum;

    [SerializeField]
    public List<List<MapNode>> nodes;

    private void Awake()
    {
        GenerateMap();
        Print();
    }

    public void GenerateMap()
    {
        Init();
        AddNode();
    }

    void Init()
    {
        nodes = new List<List<MapNode>>(levelNum);
        for (int i = 0; i < levelNum; i++)
        {
            nodes.Add(new List<MapNode>());
        }
    }

    /// <summary>
    /// 加入结点
    /// </summary>
    void AddNode()
    {
        //每一层结点的数量
        int x = UnityEngine.Random.Range(3, 5);
        //添加第一层结点
        for (int i = 0; i < x; i++)
            nodes[0].Add(new MapNode(MapNodeType.Monster));
        //添加第二层到第六层结点
        for(int i = 1;i < 6;i++)
        {
            int y = UnityEngine.Random.Range(3, 5);
            
            for(int j = 0;j < y;j++)
            {
                int nodeType = UnityEngine.Random.Range(0, 7);
                nodes[i].Add(new MapNode((MapNodeType)nodeType));
            }
                
        }

        //添加第七层结点
        x = UnityEngine.Random.Range(3, 5);
        for (int i = 0; i < x; i++)
            nodes[6].Add(new MapNode(MapNodeType.Bonus));

        //添加第八到第十层结点
        for (int i = 7; i < 10; i++)
        {
            int y = UnityEngine.Random.Range(3, 5);

            for (int j = 0; j < y; j++)
            {
                int nodeType = UnityEngine.Random.Range(0, 7);
                nodes[i].Add(new MapNode((MapNodeType)nodeType));
            }

        }

        //添加第十一层结点
        x = UnityEngine.Random.Range(3, 5);
        for (int i = 0; i < x; i++)
            nodes[10].Add(new MapNode(MapNodeType.Island));

        //添加第十二层结点
        nodes[11].Add(new MapNode(MapNodeType.Boss));
    }

    //测试用
    void Print()
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
        print(s.ToString());
    }
}
