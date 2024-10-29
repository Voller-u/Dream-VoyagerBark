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
        Debug.Log("���˳���");
        OnListCountChange?.Invoke();
    }

    public new void Remove(Enemy enemy)
    {
        base.Remove(enemy);
        Debug.Log("��������");
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
    /// ѡ�е�Ŀ�����
    /// </summary>
    public Enemy targetEnemy;

    /// <summary>
    /// �ж��ĵ���
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
