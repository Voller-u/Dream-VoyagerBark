using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI基类
/// </summary>
public class UIBase : MonoBehaviour
{
    /// <summary>
    /// 显示UI
    /// </summary>
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// 隐藏UI
    /// </summary>
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }


    /// <summary>
    /// 关闭UI
    /// </summary>
    public virtual void Close()
    {
        Destroy(gameObject);
    }
}
