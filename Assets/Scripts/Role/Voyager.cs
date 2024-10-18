using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voyager : Role
{
    


    private void OnEnable()
    {
        RoleManager.Instance.role = this;
    }


}
