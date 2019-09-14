using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBullet : BulletBase
{

    public override void Initialize(int power)
    {
        this.Power = power;


    }
    public override void Move()
    {
        //Debug.Log("Move");
        gameObject.transform.Translate(0, speed * (float)GameManager.Instance.timeManager.DeltaTime(), 0);
    }
}
