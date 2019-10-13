using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : BulletBase
{
    private CapsuleCollider2D bulletCollider;
    [SerializeField] private float width=100;


    public override void Initialize(int power)
    {
        this.Power = power;
        bulletCollider = GetComponent<CapsuleCollider2D>();
    }
    public override void Move()
    {
        //Debug.Log("Move");
        gameObject.transform.Translate(0, speed * (float)GameManager.Instance.timeManager.DeltaTime(), 0);
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.GetComponent<EnemyController>() != null)
        {
            Debug.Log("fireBullet");
            //bombSource.Play();
            // 衝突時に衝突判定範囲を拡大する
            //GameManager.Instance.damageManager.CreateBombEffect(width, transform.position);
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, width, Vector2.up, 0f);
            //Debug.Log("fireBullet:"+hits.Length);
            for (int i = 0; i < hits.Length; i++)
            {
                EnemyController enemy = hits[i].collider.gameObject.GetComponent<EnemyController>();
                if (enemy == null) continue;
                GameManager.Instance.collisionManager.CollisionBulletToEnemy(enemy, this);
            }
            var effectPos = collider.gameObject.GetComponent<EnemyController>().transform.position;
            Instantiate(hitEffect, effectPos, Quaternion.Euler(Vector3.zero));
           

        }

        // base.OnTriggerEnter2D(bulletCollider);
    }

}
