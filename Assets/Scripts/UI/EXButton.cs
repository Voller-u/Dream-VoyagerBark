using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
/// <summary>
/// ��ǿ�水ť
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

    /// <summary>
    /// ָ����밴ť�¼�
    /// </summary>
    public UnityEvent OnEnter;

    /// <summary>
    /// ָ���뿪��ť�¼�
    /// </summary>
    public UnityEvent OnExit;


    [SerializeField]
    [Header("��������ʱ��")]
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
        get => pressBeginTime; set => pressBeginTime = value;
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

        //�������������£��Ͳ�����
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
        //����������̧�𣬾Ͳ�����
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
