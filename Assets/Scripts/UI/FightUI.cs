using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightUI : UIBase
{
    public Text unusedCardNum;
    public Text usedCardNum;
    public Button endRoundButton;

    private void Start()
    {
        endRoundButton.onClick.AddListener(() =>
        {
            FightCardManager.Instance.RemoveAllCards();
            FightManager.Instance.ChangeType();
            
        });
    }

    private void Update()
    {
        unusedCardNum.text = FightCardManager.Instance.unusedCardList.Count.ToString();
        usedCardNum.text = FightCardManager.Instance.usedCardList.Count.ToString();
    }


    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Close()
    {
        base.Close();
    }

    public override void SetInteractable(bool interactable)
    {
        endRoundButton.interactable = interactable;
    }
}
