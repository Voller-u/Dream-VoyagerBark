using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/CardData", fileName = "NewCardData")]
public class CardData : ScriptableObject
{
    public int normalExpense;
    public int speicalExpense;

}
