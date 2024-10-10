using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voyager : Role
{
    private void OnEnable()
    {
        RoleManager.Instance.role = this;
    }
}
