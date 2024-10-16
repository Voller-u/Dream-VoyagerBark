using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : UIBase
{
    public MapInfo mapInfo = new MapInfo();
    private void Awake()
    {
        mapInfo.InitMap();
        
    }
}
