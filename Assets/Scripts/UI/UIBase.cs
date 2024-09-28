using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI����
/// </summary>
public class UIBase : MonoBehaviour
{
    /// <summary>
    /// ��ʾUI
    /// </summary>
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    /// <summary>
    /// ����UI
    /// </summary>
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }


    /// <summary>
    /// �ر�UI
    /// </summary>
    public virtual void Close()
    {
        Destroy(gameObject);
    }
}
