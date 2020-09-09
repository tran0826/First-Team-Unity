using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private List<EnemyPlayerPair> enemyPlayerCoList = new List<EnemyPlayerPair>();
    private List<EnemyBulletPair> enemyBulletCoList = new List<EnemyBulletPair>();

    private DamageManager damageManager;

    private void Awake()
    {
        damageManager = GameManager.Instance.damageManager;
    }

    public void UpdateByFrame()
    {
        damageManager.SetCoList(enemyBulletCoList, enemyPlayerCoList);
        ResetCoList();
    }

    private void ResetCoList()
    {
        enemyPlayerCoList.Clear();
        enemyBulletCoList.Clear();
    }

    //敵と弾の衝突時に呼び出し
    public void CollisionBulletToEnemy(EnemyController enemy,BulletBase bullet)
    {
        EnemyBulletPair pair = new EnemyBulletPair(enemy,bullet);
        enemyBulletCoList.Add(pair);
    }

    public void CollisionEnemyToPlayer(EnemyController enemy,PlayerController player)
    {
        EnemyPlayerPair pair = new EnemyPlayerPair(enemy, player);
        enemyPlayerCoList.Add(pair);
    }

}

public class EnemyPlayerPair
{
    public EnemyController enemy;
    public PlayerController player;
    
    public EnemyPlayerPair(EnemyController enemy,PlayerController player)
    {
        this.enemy = enemy;
        this.player = player;
    }
}

public class EnemyBulletPair
{
    public EnemyController enemy;
    public BulletBase bullet;

    public EnemyBulletPair(EnemyController enemy,BulletBase bullet)
    {
        this.enemy = enemy;
        this.bullet = bullet;
    }
}