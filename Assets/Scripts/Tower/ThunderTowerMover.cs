using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class ThunderTowerMover : ITowerMover
{
    private GameObject gameObject;
    private float speed;
    private bool flag;

    private GameObject targetEnemy;
    private float targetAngle = 0;
    private float nowAngle = 0;
    private float interval;
    private int power;

    private double time;

    private float range = 250;
    private float power_ratio = 1.1f;
    private float interval_ratio = 0.8f;

    BulletType bulletType = BulletType.Thunder;
    private GameObject bulletPrefab;

    public ThunderTowerMover(GameObject gameObject, GameObject bulletPrefab)
    {
        this.gameObject = gameObject;
        this.bulletPrefab = bulletPrefab;
    }

    public void OnEnter()
    {
        interval = GameManager.Instance.playerManager.Interval;
        power = GameManager.Instance.playerManager.Power;
        time = 0;
        targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(gameObject, range);
        flag = false;
    }

    public void OnUpdate()
    {
        time += GameManager.Instance.timeManager.DeltaTime();
        if (time >= interval)
        {
            CreateBullet();
            time -= interval;
        }
        RotateTower();
        float r = 6.0f * (float)GameManager.Instance.timeManager.DeltaTime();
        if (r > 1.0f) r = 1.0f;
        nowAngle += (targetAngle - nowAngle) * r;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, nowAngle);
        
    }

    public void OnEnd()
    {

    }

    public void RotateTower()
    {
        if (targetEnemy == null)
        {
            targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(this.gameObject, range);
            time = 0;
        }
        if (targetEnemy != null)
        {
            var diff = gameObject.transform.position - targetEnemy.transform.position;
            var axis = Vector3.Cross(gameObject.transform.forward, diff);
            targetAngle = Vector3.Angle(new Vector3(0f, -1f, 0f), diff) * (axis.y < 0 ? -1 : 1);
            if (targetAngle - nowAngle >= 180)
            {
                if (targetAngle > 0)
                {
                    targetAngle -= 360;
                }
                else
                {
                    nowAngle += 360;
                }
            }
            else if (targetAngle - nowAngle <= -180)
            {
                if (targetAngle < 0)
                {
                    targetAngle += 360;
                }
                else
                {
                    nowAngle -= 360;
                }
            }
        }
    }

    public void CreateBullet()
    {
        SetParam();
        if (targetEnemy == null) return;

        var bullet = GameObject.Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, targetAngle)).GetComponent<BulletBase>();
        bullet.Initialize(power);

        Vector3 distVec = gameObject.transform.position - targetEnemy.transform.position;
        float dist = distVec.magnitude;
        if (range < dist)
        {
            targetEnemy = null;
        }

    }

    public void SetParam()
    {
        power = (int)((float)GameManager.Instance.sharedValue.PowerLevel / (float)Define.MAX_PLAYER_LEVEL
            * (Define.MAX_POWER - Define.MIN_POWER) * power_ratio) + Define.MIN_POWER;
        interval = (float)(Define.MAX_PLAYER_LEVEL - GameManager.Instance.sharedValue.IntervalLevel) / (float)Define.MAX_PLAYER_LEVEL
            * (Define.MAX_INTERVAL - Define.MIN_INTERVAL) * interval_ratio + Define.MIN_INTERVAL;
    }
}
