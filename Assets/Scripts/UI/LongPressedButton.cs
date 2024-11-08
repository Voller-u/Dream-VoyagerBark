using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// ������ť
/// </summary>
[AddComponentMenu("UI/LongPressedButton",31)]
public class LongPressedButton : Selectable
{
    /// <summary>
    /// ��ť���´������¼�
    /// </summary>
    public UnityEvent BeginPressed;
    /// <summary>
    /// ��ť����״̬�������¼�
    /// </summary>
    public UnityEvent Pressed;
    /// <summary>
    /// ��ţ̌�𴥷����¼�
    /// </summary>
    public UnityEvent EndPressed;
    /// <summary>
    /// ��ť����¼�
    /// </summary>
    public UnityEvent OnClick;

    [SerializeField]
    private float longPressTime = 0.3f;

    /// <summary>
    /// ��������ʱ��
    /// </summary>
    public float LongPressTime
    {
        get => longPressTime; set => longPressTime = value;
    }


    private float pressBeginTime;
    /// <summary>
    /// ������ʼʱ��
    /// </summary
    public float PressBeginTime
    {
        get => pressBeginTime; set=>pressBeginTime = value;
    }

    private float pressTime;

    /// <summary>
    /// ����״̬��ʱ��
    /// </summary>
    public float PressTime
    {
        get => pressTime; set => pressTime = value;
    }


    private float pressEndTime;
    /// <summary>
    /// ��ţ̌��ʱ��
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
        //�������������£��Ͳ�����
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        BeginPressed.Invoke();
        buttonPressed = true;
        pressBeginTime = Time.time;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //����������̧�𣬾Ͳ�����
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        pressEndTime = Time.time;
        if (pressEndTime - pressBeginTime < longPressTime)
            OnClick.Invoke();
        EndPressed.Invoke();
        buttonPressed = false;
    }

    
}
