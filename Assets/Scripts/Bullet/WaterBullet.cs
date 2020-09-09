using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : BulletBase
{
    private float[] speed_ratio= { 0.9f ,0.8f, 0.7f};
    public override void Initialize(int power)
    {
        this.Power = power;
        this.bulletType = BulletType.Water;
    }
    public override void Move()
    {
        //Debug.Log("Move");
        gameObject.transform.Translate(0, speed * (float)GameManager.Instance.timeManager.DeltaTime(), 0);
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {

        var enemy = collider.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            nowLevel=GameManager.Instance.sharedValue.ThunderLevel;
            enemy.SpeedDown(speed_ratio[nowLevel]);
            GameManager.Instance.collisionManager.CollisionBulletToEnemy(enemy, this);
            var effectPos = collider.gameObject.GetComponent<EnemyController>().transform.position;
            effectPos.z = -5;
            Instantiate(hitEffect, effectPos, Quaternion.Euler(Vector3.zero));
            return;
        }
    }

}
