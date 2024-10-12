using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : UIBase
{
    private void Awake()
    {
        MapInfo.Instance.InitMap();
    }
}
