using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightWIn : FightUnit
{
    public override void Init()
    {
        
        UIManager.Instance.ShowUI<FightWinUI>("FightWinUI");
    }

    public override void OnUpdate()
    {

    }


}
