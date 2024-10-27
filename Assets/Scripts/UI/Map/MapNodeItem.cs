using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.EventSystems;

[Serializable]
public class MapNodeItem : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public MapNode mapNode;
    public Text text;
    public GameObject dotPrefab;

    private Image image;

    public List<MapNodeItem> nextNodes = new List<MapNodeItem>();

    private bool active;
    public bool Active
    {
        set
        {
            active = value;
            if(active)
            {
                StartCoroutine(Anim());
            }
            else
            {
                StopCoroutine(Anim());
                transform.localScale = Vector3.one;
            }
        }
    }

    private bool dead;
    public bool Dead
    {
        set
        {
            if(value)
            {
                image.color = Color.white;
            }
            else
            {
                image.color = new Color(255, 255, 255, 127);
            }
            dead = value;
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
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
                transform.DOScale(1.2f, 0.5f);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!active && !dead)
        {
            transform.DOScale(1.2f, 0.5f);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!active && !dead)
        {
            transform.DOScale(1f, 0.5f);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(active)
        {
            GameManager.Instance.MapEventHandler(mapNode.type);
            active = false;
            Dead = true;
            UIManager.Instance.GetUI<MapUI>("MapUI")?.selectedNodes.Add(this);
            
        }
    }
}
