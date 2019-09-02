using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private Queue<EnemyBulletPair> enemyBulletCoList = new Queue<EnemyBulletPair>();



    private void Awake()
    {

    }


    public void SetCoList(List<EnemyBulletPair> ebList)
    {
        foreach(var enemyBulletPair in ebList)
        {
            enemyBulletCoList.Enqueue(enemyBulletPair);
        }
    }

    public void UpdateByFrame()
    {
        ExecEnemyBulletProcess();
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
