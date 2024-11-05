using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightPlayer : FightUnit
{


    public override void Init()
    {
        //UIManager.Instance.ShowTip("玩家回合", Color.black, delegate ()
        //{
            
        //});
        //抽牌
        Debug.Log("从牌堆中抽牌");
        FightCardManager.Instance.AddCard(FightCardManager.Instance.drawCardNum);
        UIManager.Instance.SetInteractableUI("FightUI", true);

        RoleManager.Instance.role.InvokeBeginAction();
    }

    public override void OnUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 screenPos =Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero, 100f, 1 << LayerMask.NameToLayer("Enemy"));
            if(hit)
            {
                Enemy enemy = hit.collider.gameObject.GetComponent<Enemy>();
                if(enemy != null)
                {
                    EnemyManager.Instance.targetEnemy = enemy;
                }
            }
        }
    }
}
