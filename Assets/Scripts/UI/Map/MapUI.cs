using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class MapUI : UIBase
{
    public static string path = Application.streamingAssetsPath + "/MapData/map";
    public MapInfo mapInfo = new MapInfo();
    public List<MapNodeItem> selectedNodes = new List<MapNodeItem>();
    public Transform content;
    public List<List<MapNodeItem>> mapNodeItems = new List<List<MapNodeItem>>();

    public Button closeButton;
    
    private void Awake()
    {
        try
        {
            mapInfo = Tools.ReadClass<MapInfo>(path);
        }
        catch (FileNotFoundException)
        {
            Debug.Log("地图不存在，重新创建");
            mapInfo.InitMap();
        }

        EventManager.Instance.OnDestroySaveEvent += () => Tools.SaveClass<MapInfo>(mapInfo, path);
        
        mapInfo.RevertNode(mapInfo.curMapNode);
            

        GenerateMap();

        closeButton.onClick.AddListener(Hide);

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
                item.Init();
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
        if(selectedNodes.Count > 0)
        {
            MapNodeItem node = selectedNodes[^1];
            for(int i=0;i<node.nextNodes.Count;i++)
            {
                if (!node.nextNodes[i].Selected)
                    node.nextNodes[i].Active = true;
            }
        }
    }

    public void ToNextLayer()
    {
        for (int i = 0; i < mapNodeItems[mapInfo.curLevelNum].Count; i++)
        {
            mapNodeItems[mapInfo.curLevelNum][i].Active = false;
        }
        mapInfo.curLevelNum++;
        mapInfo.curMapNode = null;
    }

}
