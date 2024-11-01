using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [Header("���������")]
    public int maxCardNum;

    [Header("���")]
    public float spacing;

    private int previousChildNum;

    public Transform leftBound;
    public Transform rightBound;

    private void OnTransformChildrenChanged()
    {
        if(transform.childCount > maxCardNum)
        {
            Debug.LogError("����������������");
        }
        //���������ı䣬��Ҫ����ui
        if(transform.childCount != previousChildNum)
        {
            Refresh(DynamicSpacing());
            
        }
        previousChildNum = transform.childCount;
    }

    private float DynamicSpacing()
    {
        
        if (transform.childCount > 8) 
        {
            float space = 0;
            space = (rightBound.transform.localPosition.x - leftBound.transform.localPosition.x) / (transform.childCount - 1);
            float width = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
            space -= width;
            return space;
        }
        return spacing;
    }
    
    private void Refresh(float space)
    {
        if (transform.childCount > 0)
        {
            float width = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.localPosition = new Vector3(width / 2 + (width + space) * i, 0, 0);
            }
        }
    }
}
