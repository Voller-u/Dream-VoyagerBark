using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 长按按钮
/// </summary>
[AddComponentMenu("UI/LongPressedButton",31)]
public class LongPressedButton : Selectable
{
    /// <summary>
    /// 按钮按下触发的事件
    /// </summary>
    public UnityEvent BeginPressed;
    /// <summary>
    /// 按钮长按状态触发的事件
    /// </summary>
    public UnityEvent Pressed;
    /// <summary>
    /// 按钮抬起触发的事件
    /// </summary>
    public UnityEvent EndPressed;
    /// <summary>
    /// 按钮点击事件
    /// </summary>
    public UnityEvent OnClick;

    [SerializeField]
    private float longPressTime = 0.3f;

    /// <summary>
    /// 长按触发时间
    /// </summary>
    public float LongPressTime
    {
        get => longPressTime; set => longPressTime = value;
    }


    private float pressBeginTime;
    /// <summary>
    /// 长按开始时间
    /// </summary
    public float PressBeginTime
    {
        get => pressBeginTime; set=>pressBeginTime = value;
    }

    private float pressTime;

    /// <summary>
    /// 长按状态的时间
    /// </summary>
    public float PressTime
    {
        get => pressTime; set => pressTime = value;
    }


    private float pressEndTime;
    /// <summary>
    /// 按钮抬起时间
    /// </summary>
    
    public float PressEndTime
    {
        get=>pressEndTime; set=>pressEndTime = value;
    }

    private bool buttonPressed;

    private void Update()
    {
        if(buttonPressed)
        {
            pressTime += Time.deltaTime;
            Pressed?.Invoke();
        }
        else
        {
            pressTime = 0;
        }
    }


    public override void OnPointerDown(PointerEventData eventData)
    {
        //如果不是左键按下，就不触发
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        BeginPressed.Invoke();
        buttonPressed = true;
        pressBeginTime = Time.time;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //如果不是左键抬起，就不触发
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        pressEndTime = Time.time;
        if (pressEndTime - pressBeginTime < longPressTime)
            OnClick.Invoke();
        EndPressed.Invoke();
        buttonPressed = false;
    }

    
}
