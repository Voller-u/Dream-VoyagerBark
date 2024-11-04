using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyList<Enemy> : List<Enemy>
{

    private UnityEvent onListCountChange = new UnityEvent();
    public UnityEvent OnListCountChange
    {
        get => onListCountChange;
        set => onListCountChange = value;
    }

    public new void Add(Enemy enemy)
    {
        base.Add(enemy);
        Debug.Log("敌人出现");
        OnListCountChange?.Invoke();
    }

    public new void Remove(Enemy enemy)
    {
        base.Remove(enemy);
        Debug.Log("敌人死亡");
        OnListCountChange?.Invoke();
    }

    public EnemyList(UnityAction onListCountChangeAction) :base()
    {
        OnListCountChange.AddListener(onListCountChangeAction);
    }

    
}


public class EnemyManager : BaseManager<EnemyManager>
{

    public EnemyList<Enemy> enemyList;

    /// <summary>
    /// 选中的目标敌人
    /// </summary>
    [SerializeField]
    private Enemy _targetEnemy;
    public Enemy targetEnemy
    {
        get => _targetEnemy;
        set
        {
            _targetEnemy = value;
            _targetEnemy.sprite.material = _targetEnemy.targetMaterial;

            for(int i = 0;i<enemyList.Count;i++)
            {
                if (enemyList[i] != targetEnemy)
                {
                    enemyList[i].sprite.material = enemyList[i].normalMaterial;
                }
            }
        }
    }

    /// <summary>
    /// 行动的敌人
    /// </summary>
    public Enemy actEnemy;

    private void OnListCountChange()
    {
        if(enemyList.Count <= 0)
        {
            FightManager.Instance.ChangeType(FightType.Win);
        }
    }

    public EnemyManager()
    {
        enemyList = new(OnListCountChange);
    }

    public void ChangeTarget(Enemy target)
    {
        targetEnemy = target;
    }

    public void ChangeTarget()
    {
        if(enemyList.Count > 0)
            targetEnemy = enemyList[0];
    }

}
