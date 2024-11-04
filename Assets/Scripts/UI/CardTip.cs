using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardTip : MonoBehaviour
{
    public Text cardTipText;

    public void Init(string _cardTipText)
    {
        cardTipText.text = _cardTipText;
    }
}
