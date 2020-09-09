using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBullet : BulletBase
{
    private float[] power_ratio = { 0.5f, 0.8f, 1.0f };

    public override void Initialize(int power)
    {
        this.Power = power;
        this.bulletType = BulletType.Thunder;
        CanDestroyOnCollision = false;
    }
    public override void Move()
    {
        //Debug.Log("Move");
        gameObject.transform.Translate(0, speed * (float)GameManager.Instance.timeManager.DeltaTime(), 0);
    }

    public override int RangePower(EnemyController enemy)
    {
        int rPower = this.Power;
        //Debug.Log(rPower);
        nowLevel = GameManager.Instance.sharedValue.ThunderLevel;
        this.Power = (int)((float)rPower * power_ratio[nowLevel]);
        return rPower;
    }
}
