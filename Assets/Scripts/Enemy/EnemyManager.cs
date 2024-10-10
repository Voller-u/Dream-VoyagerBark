using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : BaseManager<EnemyManager>
{
    
    public List<Enemy> enemyList = new List<Enemy>();

    /// <summary>
    /// ѡ�е�Ŀ�����
    /// </summary>
    public Enemy targetEnemy;

    /// <summary>
    /// �ж��ĵ���
    /// </summary>
    public Enemy actEnemy;

}
