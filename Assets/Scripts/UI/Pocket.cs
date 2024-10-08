using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    [Header("最大卡牌数量")]
    public int maxCardNum;

    [Header("间隔")]
    public int spacing;

    private int previousChildNum;

    private void OnTransformChildrenChanged()
    {
        if(transform.childCount > maxCardNum)
        {
            Debug.LogError("超出卡牌数量限制");
        }
        //卡牌数量改变，需要更新ui
        if(transform.childCount != previousChildNum)
        {
            if(transform.childCount > 0)
            {
                float width = transform.GetChild(0).GetComponent<RectTransform>().rect.width;
                for(int i=0;i<transform.childCount; i++)
                {
                    transform.GetChild(i).transform.localPosition = new Vector3(width / 2 + (width + spacing) * i, 0, 0);
                }
            }
        }
        previousChildNum = transform.childCount;
    }
}
