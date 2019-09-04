using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private Queue<EnemyBulletPair> enemyBulletCoList = new Queue<EnemyBulletPair>();
    private Queue<EnemyPlayerPair> enemyPlayerCoList = new Queue<EnemyPlayerPair>();

    DestroyManager destroyManager;
    TowerManager towerManager;

    SharedValue sharedValue;


    private void Awake()
    {
        destroyManager = GameManager.Instance.destroyManager;
        towerManager = GameManager.Instance.towerManager;
        sharedValue = GameManager.Instance.sharedValue;

    }


    public void SetCoList(List<EnemyBulletPair> ebList,List<EnemyPlayerPair> epList)
    {
        foreach(var enemyBulletPair in ebList)
        {
            enemyBulletCoList.Enqueue(enemyBulletPair);
        }
        foreach(var enemyPlayerPair in epList)
        {
            enemyPlayerCoList.Enqueue(enemyPlayerPair);
        }
    }

    public void UpdateByFrame()
    {
        ExecEnemyPlayerProcess();
        ExecEnemyBulletProcess();
    }


    private void ExecEnemyPlayerProcess()
    {
        if (enemyPlayerCoList.Count == 0) return;
        foreach(EnemyPlayerPair pair in enemyPlayerCoList)
        {

        }
        enemyPlayerCoList.Clear();
    }

    private void ExecEnemyBulletProcess()
    {
        if (enemyBulletCoList.Count == 0) return;
        foreach(EnemyBulletPair pair in enemyBulletCoList)
        {



        }
        enemyBulletCoList.Clear();
    }
}
