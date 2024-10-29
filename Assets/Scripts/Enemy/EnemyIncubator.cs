using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyIncubator : MonoBehaviour
{
    private static EnemyIncubator instance;
    public static EnemyIncubator Instance => instance;

    public Transform enemyIncubator;

    private void Awake()
    {
        instance = this;
    }

    public void IncubateEnemy<T>(string enemyName,int id,UnityAction<T> initEnemy = null)
    {
        Transform pos = enemyIncubator.GetChild(id);
        T enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy/" + enemyName),pos).GetComponent<T>();
        initEnemy?.Invoke(enemy);
    }

    public Enemy IncubateEnemy(string enemyName, int id)
    {
        if(id < 0 || id > enemyIncubator.childCount)
        {
            Debug.LogError("³¬³öidÏÞÖÆ");
            return null;
        }
        Transform pos = enemyIncubator.GetChild(id);
        Enemy enemy = Instantiate(Resources.Load<GameObject>("Prefabs/Enemy/" + enemyName), pos).GetComponent<Enemy>();
        return enemy;
    }
}
