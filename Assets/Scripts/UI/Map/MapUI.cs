using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : UIBase
{
    public MapInfo mapInfo = new MapInfo();
    public Transform content;
    public List<List<MapNodeItem>> mapNodeItems = new List<List<MapNodeItem>>();
    
    private void Awake()
    {
        mapInfo.InitMap();
        //测试存取
        //mapInfo.Print();
        //Tools.SaveClass<MapInfo>(mapInfo,Application.dataPath + "/map.txt");
        //mapInfo = Tools.ReadClass<MapInfo>(Application.dataPath + "/map.txt");
        //mapInfo.Print();

        GenerateMap();

    }

    public void GenerateMap()
    {
        List<MapNodeItem> formalNodes = new List<MapNodeItem>();
        List<MapNodeItem> curNodes = new List<MapNodeItem>();
        for(int i=0;i<content.childCount;i++)
        {
            mapNodeItems.Add(new List<MapNodeItem>());

            Transform level = content.GetChild(i).transform;
            for(int j = 0; j < mapInfo.nodes[i].Count;j++)
            {
                GameObject node = Instantiate(Resources.Load<GameObject>("UI/MapNode"));
                node.transform.SetParent(level);
                MapNodeItem item = node.GetComponent<MapNodeItem>();
                item.text.text = mapInfo.nodes[i][j].type.ToString();
                item.mapNode = mapInfo.nodes[i][j];
                curNodes.Add(item);
                mapNodeItems[i].Add(item);
            }
            //将当前层与上一层建立连接
            if (formalNodes.Count > 0)
            {
                for (int k = 0; k < formalNodes.Count; k++)
                {
                    for (int ii = 0; ii < formalNodes[k].mapNode.nexts.Count;ii++)
                    {
                        for(int jj=0;jj<curNodes.Count;jj++)
                        {
                            if (formalNodes[k].mapNode.nexts[ii] == curNodes[jj].mapNode)
                            {
                                formalNodes[k].nextNodes.Add(curNodes[jj]);
                            }
                        }
                    }
                    formalNodes[k].CreateLine();
                }
            }
            formalNodes.Clear();
            formalNodes.AddRange(curNodes);
            curNodes.Clear();
        }

        
    }

    public override void Show()
    {
        base.Show();
        for(int i = 0; i < mapNodeItems[mapInfo.curLevelNum].Count;i++)
        {
            mapNodeItems[mapInfo.curLevelNum][i].Active = true;

        }
    }

    public void ToNextLayer()
    {
        mapInfo.curLevelNum++;
    }

}
