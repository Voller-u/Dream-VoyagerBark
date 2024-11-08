using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(EXButton))]
public class EXButtonEditor: Editor
{
    private EXButton _button;

    private readonly string[] _type = { "Normal Button","LP Button","Not Button","All" };

    private int _typeIndex = 0;

    private SerializedProperty _OnClickEvent;
    private SerializedProperty _OnEnterEvent;
    private SerializedProperty _OnExitEvent;

    private SerializedProperty _BeginPressedEvent;
    private SerializedProperty _PressedEvent;
    private SerializedProperty _EndPressedEvent;
    private void OnEnable()
    {
        //获取当前编辑自定义Inspector的对象
        _button = (EXButton)target;

        _OnClickEvent = serializedObject.FindProperty(nameof(_button.OnClick));
        _OnEnterEvent = serializedObject.FindProperty(nameof(_button.OnEnter));
        _OnExitEvent = serializedObject.FindProperty(nameof(_button.OnExit));
        _BeginPressedEvent = serializedObject.FindProperty(nameof(_button.BeginPressed));
        _PressedEvent = serializedObject.FindProperty(nameof(_button.Pressed));
        _EndPressedEvent = serializedObject.FindProperty(nameof(_button.EndPressed));
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        _button.gameObject.name = EditorGUILayout.TextField("名字", _button.gameObject.name);

        _typeIndex = EditorGUILayout.Popup("Button Type", _typeIndex, _type);

        _button.buttonType = (EXButton.ButtonType)_typeIndex;

        switch (_typeIndex)
        {
            
            case 0:
                NormalButtonGUI();
                break;
            case 1:
                LPButtonGUI();
                break;
            case 2:
                NotButtonGUI();
                break;
            case 3:
                NormalButtonGUI();
                LPButtonGUI();
                NotButtonGUI();
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void NormalButtonGUI()
    {
        EditorGUILayout.PropertyField(_OnClickEvent);

    }

    private void LPButtonGUI()
    {
        EditorGUILayout.PropertyField(_OnClickEvent);
        EditorGUILayout.PropertyField(_BeginPressedEvent);
        EditorGUILayout.PropertyField(_PressedEvent);
        EditorGUILayout.PropertyField(_EndPressedEvent);

        _button.LongPressTime = EditorGUILayout.FloatField("长按触发时间", _button.LongPressTime);
    }

    private void NotButtonGUI()
    {
        EditorGUILayout.PropertyField(_OnEnterEvent);
        EditorGUILayout.PropertyField(_OnExitEvent);
    }

    [MenuItem("GameObject/UI/EXButton")]
    public static void CreateEXButton()
    {
        Transform parentTransform = null;
        Transform canvasTransform = null;

        if (Selection.activeGameObject != null)
        {
            parentTransform = Selection.activeGameObject.transform;
            if (Selection.activeGameObject.GetComponent<Canvas>() != null)
                canvasTransform = Selection.activeGameObject.transform;
            else
            {
                Transform tf = Selection.activeGameObject.transform.Find("Canvas");
                if (tf != null)
                    canvasTransform = tf;
                else
                {
                    canvasTransform = CreateCanvas(parentTransform);
                }
            }
        }
        else
        {
            Canvas[] canvases = FindObjectsOfType<Canvas>();
            bool haveCanvas = false;
            for (int i = 0; i < canvases.Length; i++)
            {
                if (canvases[i].transform.parent == null)
                {
                    canvasTransform = canvases[i].transform;
                    haveCanvas = true;
                    break;
                }
            }
            if (!haveCanvas)
            {
                canvasTransform = CreateCanvas(null);
            }
        }

        //实例化物体
        GameObject buttonObj = new GameObject("EXButton");
        buttonObj.transform.SetParent(canvasTransform);

        //设置RectTransform
        RectTransform rectTransform = buttonObj.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(160, 30);
        rectTransform.anchoredPosition = new Vector2(0, 0);

        //添加长按按钮组件
        EXButton button = buttonObj.AddComponent<EXButton>();

        Image image = buttonObj.AddComponent<Image>();
        image.sprite = AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
    }

    private static Transform CreateCanvas(Transform transform)
    {
        GameObject canvasObj = new GameObject("Canvas");
        canvasObj.transform.SetParent(transform);
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        return canvasObj.transform;

    }
}
