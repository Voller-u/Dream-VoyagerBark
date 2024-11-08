using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class LongPressedButtonEditor : MonoBehaviour
{
    [MenuItem("GameObject/UI/LongPressedButton")]
    public static void CreateLongPressedButton()
    {
        Transform parentTransform = null;
        Transform canvasTransform = null;

        if(Selection.activeGameObject != null)
        {
            parentTransform = Selection.activeGameObject.transform;
            if(Selection.activeGameObject.GetComponent<Canvas>() != null)
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
            for(int i=0;i<canvases.Length; i++)
            {
                if (canvases[i].transform.parent ==null)
                {
                    canvasTransform = canvases[i].transform;
                    haveCanvas = true;
                    break;
                }
            }
            if(!haveCanvas)
            {
                canvasTransform = CreateCanvas(null);
            }
        }

        //实例化物体
        GameObject buttonObj = new GameObject("LongPressedButton");
        buttonObj.transform.SetParent(canvasTransform);

        //设置RectTransform
        RectTransform rectTransform = buttonObj.AddComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(160, 30);
        rectTransform.anchoredPosition = new Vector2(0, 0);

        //添加长按按钮组件
        LongPressedButton button = buttonObj.AddComponent<LongPressedButton>();

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
