using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// сно╥хК©з
/// </summary>
public class GameApp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }

    
}
