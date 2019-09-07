using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBase
{
    
    public override void Initialize(int power,Vector3 targetPos) {
        float angle = Vector3.Angle(this.transform.position,targetPos);
        transform.RotateAround(this.transform.position,this.transform.forward,angle);

    }
    public override void Move() {
        Debug.Log("Move");
        gameObject.transform.Translate(0, speed * 0.001f / 5, 0);
    }
}
