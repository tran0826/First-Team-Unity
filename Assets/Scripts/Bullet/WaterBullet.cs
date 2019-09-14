using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBullet : BulletBase
{
    [SerializeField] private float ratio=0.8f;
    public override void Initialize(int power)
    {
        this.Power = power;
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
            enemy.SpeedDown(ratio);
            GameManager.Instance.collisionManager.CollisionBulletToEnemy(enemy, this);
            return;
        }
    }

}
