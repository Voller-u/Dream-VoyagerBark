using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[Serializable]
public class MapNodeItem : MonoBehaviour
{
    public MapNode mapNode;
    public Text text;
    public GameObject dotPrefab;
    public List<MapNodeItem> nextNodes = new List<MapNodeItem>();

    public bool active;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(Anim());
    }

    private void OnDisable()
    {
        StopCoroutine(Anim());
        transform.localScale = Vector3.one;
    }

    IEnumerator Anim()
    {
        if (active)
        {
            while (true)
            {
                transform.DOScale(1.5f, 0.5f);
                yield return new WaitForSeconds(0.5f);
                transform.DOScale(1f, 0.5f);
                yield return new WaitForSeconds(0.5f);
            }
        }
        
    }

    public void CreateLine()
    {
        for (int i = 0; i < nextNodes.Count; i++)
        {
            Transform transform1 = transform;
            Transform transform2 = nextNodes[i].transform;
            
            for(int j=1;j<10;j++)
            {
                float t = (float)j / 10;
                GameObject dot = Instantiate(dotPrefab);
                dot.transform.SetParent(transform);
                
                dot.transform.position = transform1.position * t + transform2.position * (1 - t);
            }
        }
    }
}
