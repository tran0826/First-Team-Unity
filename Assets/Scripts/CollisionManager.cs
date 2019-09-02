using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{

    private List<EnemyBulletPair> enemyBulletCoList = new List<EnemyBulletPair>();

    private DamageManager damageManager;

    private void Awake()
    {
        damageManager = GameManager.Instance.damageManager;
    }

    public void UpdateByFrame()
    {




        ResetCoList();
    }

    private void ResetCoList()
    {
        enemyBulletCoList.Clear();
    }

    //敵と弾の衝突時に呼び出し
    public void CollisionBulletToEnemy(EnemyController enemy)
    {
        EnemyBulletPair pair = new EnemyBulletPair(enemy);
        enemyBulletCoList.Add(pair);
    }
}

public class EnemyBulletPair
{
    public EnemyController enemy;
//    public BulletBase bullet;

    public EnemyBulletPair(EnemyController enemy)
    {
        this.enemy = enemy;
    }
}