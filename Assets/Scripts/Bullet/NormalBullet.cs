using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBase
{
    private float[] power_ratio = {1.0f,1.2f,1.5f};
    public override void Initialize(int power) {
        this.Power = power;
        this.bulletType = BulletType.Normal;
    }
    public override void Move() {
        //Debug.Log("Move");
        gameObject.transform.Translate(0, speed *(float)GameManager.Instance.timeManager.DeltaTime(), 0);
    }
    public override int RangePower(EnemyController enemy)
    {
        nowLevel = GameManager.Instance.sharedValue.NormalLevel;
        return (int)((float)this.Power * power_ratio[nowLevel]);
    }
}
