using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBase
{
    
    public override void Initialize(int power) {
        this.Power = power;

        
    }
    public override void Move() {
        //Debug.Log("Move");
        gameObject.transform.Translate(0, speed * 0.1f / 5*(float)GameManager.Instance.timeManager.DeltaTime(), 0);
    }
}
