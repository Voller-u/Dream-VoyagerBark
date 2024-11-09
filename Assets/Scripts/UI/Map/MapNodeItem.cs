using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

[Serializable]
public class MapNodeItem : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler
{
    public MapNode mapNode;
    private string nodeType;
    public string NodeType
    {
        get => nodeType;
        set
        {
            nodeType = value;
            image.sprite = Resources.Load<Sprite>("Map/" + nodeType);
            if (nodeType.Equals("Boss"))
            {
                RectTransform rect = GetComponent<RectTransform>();
                rect.sizeDelta = new Vector2(rect.rect.width * 2, rect.rect.height * 2);
            }
        }
    }
    public GameObject HollowLine;
    public GameObject SolidLine;

    private Image image;



    public List<MapNodeItem> nextNodes = new List<MapNodeItem>();
    
    public List<GameObject> hollowLines = new List<GameObject>();
    public List<GameObject> solidLines = new List<GameObject>();

    public bool Active
    {
        set
        {
            mapNode.active = value;
            if(value && !Selected)
            {
                //StartCoroutine(Anim());
            }
            else
            {
                //StartCoroutine(StopAnim());
                transform.localScale = Vector3.one;
                if(!Selected)
                {
                    image.color = new Color(255, 255, 255, 127);
                }
            }
        }
    }

    public bool Selected
    {
        get => mapNode.selected;
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
            mapNode.selected = value;
        }
    }

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    IEnumerator Anim()
    {
            while (mapNode.active && !Selected)
            {
                transform.DOScale(1.5f, 0.5f);
                yield return new WaitForSeconds(0.5f);
                transform.DOScale(1f, 0.5f);
                yield return new WaitForSeconds(0.5f);
            }
        
    }


    public void CreateLine()
    {
        for(int i=0;i<nextNodes.Count;i++)
        {
            CreateLine(nextNodes[i].transform, HollowLine);
            CreateLine(nextNodes[i].transform,SolidLine,false);
        }
    }

    private void CreateLine(Transform other,GameObject linePrefab,bool show = true)
    {
        GameObject line = Instantiate(linePrefab, transform);
        if(linePrefab == HollowLine)
            hollowLines.Add(line);
        else
            solidLines.Add(line);

        line.SetActive(show);

        RectTransform rect = line.GetComponent<RectTransform>();
        Vector2 start = transform.position;
        Vector2 end = other.transform.position;

        //MapLine mapLine = line.GetComponent<MapLine>();
        //mapLine.start = start;
        //mapLine.end = end;

        rect.position = new Vector2((end.x + start.x) / 2,
            (end.y + start.y) / 2);

        rect.localRotation = Quaternion.AngleAxis(-GetAngle(start, end), Vector3.forward);


        var distance = Vector2.Distance(start, end);
        rect.sizeDelta = new Vector2(40, distance);
    }

    private float GetAngle(Vector2 start, Vector2 end)
    {
        return Vector2.SignedAngle(end - start, Vector2.down);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!mapNode.active && !mapNode.selected)
        {
            transform.DOScale(1.5f, 0.5f);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!mapNode.active && !mapNode.selected)
        {
            transform.DOScale(1f, 0.5f);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(mapNode.active)
        {
            
            Active = false;
            
            MapUI map = UIManager.Instance.GetUI<MapUI>("MapUI");

            map.mapInfo.curLevelNum = map.GetMapNodeItemLayer(this);

            for (int i = 0; i < map.mapNodeItems[map.mapInfo.curLevelNum].Count;i++)
            {
                map.mapNodeItems[map.mapInfo.curLevelNum][i].Active = false;
            }

            //更新线路
            if(map.selectedNodes.Count >0)
            {
                for(int i = 0; i < map.selectedNodes[^1].nextNodes.Count; i++)
                {
                    if (map.selectedNodes[^1].nextNodes[i] == this)
                    {
                        map.selectedNodes[^1].nextNodes[i].mapNode.nextNode = mapNode;
                        map.selectedNodes[^1].ShowSolidLine(i);
                    }
                }
            }


            map?.selectedNodes.Add(this);
            map.mapInfo.selectedNodes.Add(this.mapNode);
            map.mapInfo.curMapNode = mapNode;
            Selected = true;

            GameManager.Instance.MapEventHandler(mapNode.type);
        }
    }

    public void ShowSolidLine(int index)
    {
        hollowLines[index].SetActive(false);
        solidLines[index].SetActive(true);
    }

    private Coroutine animCoroutine;
    private void Update()
    {
        if(mapNode.active && !Selected)
        {
            if(gameObject.activeInHierarchy)
            {
                if(animCoroutine == null )
                    animCoroutine = StartCoroutine(Anim());
            }
        }
        else
        {
            if (gameObject.activeInHierarchy)
            {
                if(animCoroutine != null)
                    StopCoroutine(Anim());
                animCoroutine = null;

            }
            
        }
    }
}
