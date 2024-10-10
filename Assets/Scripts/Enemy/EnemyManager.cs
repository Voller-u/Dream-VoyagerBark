using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : BaseManager<EnemyManager>
{
    
    public List<Enemy> enemyList = new List<Enemy>();

    /// <summary>
    /// 选中的目标敌人
    /// </summary>
    public Enemy targetEnemy;

    /// <summary>
    /// 行动的敌人
    /// </summary>
    public Enemy actEnemy;

}
