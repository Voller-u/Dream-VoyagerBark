using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : UIBase
{
    public MapInfo mapInfo;
    private void Awake()
    {
        mapInfo = new MapInfo();
        mapInfo.InitMap();
        mapInfo.Print();
        Tools.SaveClass<MapInfo>(mapInfo, Application.dataPath + "map.txt");

        mapInfo = Tools.ReadClass<MapInfo>(Application.dataPath + "map.txt");
        mapInfo.Print();
    }
}
