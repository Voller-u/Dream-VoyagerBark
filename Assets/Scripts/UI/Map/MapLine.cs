using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLine : MonoBehaviour
{
    public Vector2 start;
    public Vector2 end;

    private RectTransform rect;
    private RectTransform parentRect;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        //rect.position = new Vector2((end.x + start.x) / 2,
            //(end.y + start.y) / 2);
        parentRect = transform.parent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.localScale = CalScale();

        //rect.localRotation = Quaternion.AngleAxis(-GetAngle(start, end), Vector3.forward);


        //var distance = Vector2.Distance(start, end);
        //rect.sizeDelta = new Vector2(40, distance);
    }

    private Vector3 CalScale()
    {
        return new Vector3(1 / parentRect.localScale.x, 1 / parentRect.localScale.y, 1 / parentRect.localScale.z);
    }
}
