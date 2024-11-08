using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// 增强版按钮
/// </summary>
[AddComponentMenu("UI/EXButton", 37)]
public class EXButton : Selectable
{
    public enum ButtonType
    {
        NormalButton,
        LPButton,
        NotButton,
        All
    }

    public ButtonType buttonType;

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

    /// <summary>
    /// 指针进入按钮事件
    /// </summary>
    public UnityEvent OnEnter;

    /// <summary>
    /// 指针离开按钮事件
    /// </summary>
    public UnityEvent OnExit;


    [SerializeField]
    [Header("长按触发时间")]
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
        get => pressBeginTime; set => pressBeginTime = value;
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
        get => pressEndTime; set => pressEndTime = value;
    }

    private bool buttonPressed;

    private void Update()
    {
        if (buttonPressed)
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
        if (!(buttonType == ButtonType.LPButton || buttonType == ButtonType.All))
        {
            if(buttonType == ButtonType.NormalButton)
            {
                OnClick?.Invoke();
            }
            return;
        }

        //如果不是左键按下，就不触发
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        BeginPressed?.Invoke();
        buttonPressed = true;
        pressBeginTime = Time.time;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if(!(buttonType == ButtonType.LPButton || buttonType == ButtonType.All))
            return;
        //如果不是左键抬起，就不触发
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        pressEndTime = Time.time;
        if (pressEndTime - pressBeginTime < longPressTime)
            OnClick?.Invoke();
        EndPressed?.Invoke();
        buttonPressed = false;
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if(buttonType == ButtonType.NotButton || buttonType == ButtonType.All)
            OnEnter?.Invoke();
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (buttonType == ButtonType.NotButton || buttonType == ButtonType.All)
            OnExit?.Invoke();
    }
}
