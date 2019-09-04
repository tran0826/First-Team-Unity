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
        foreach (EnemyBulletPair pair in enemyBulletCoList)
        {
            int bulletPower = pair.bullet.Power;

            DisplayHitEffect(pair.bullet.transform.position);
            if (pair.bullet.CanDestroyOnCollision)
            {
                destroyManager.AddDestroyList(pair.bullet.gameObject);
            }
            pair.enemy.HitBullet(bulletPower);
            /*
            if (pair.enemy.getHP() <= 0)
            {
                EnemyDead(enemy);
            }
            */
        }
        enemyBulletCoList.Clear();
    }

    private void EnemyDead(EnemyController enemy)
    {
 //       towerManager.Kill(enemy.gameObject);
  //      enemy.DeadOnRule();
        destroyManager.AddDestroyList(enemy.gameObject);
    }

    private void DisplayHitEffect(Vector3 pos)
    {

    }


}
