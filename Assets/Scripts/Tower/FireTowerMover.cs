using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTowerMover : ITowerMover
{
    private GameObject gameObject;
    private float speed;
    private bool flag;

    private GameObject targetEnemy;
    private float targetAngle = 0;
    private float nowAngle = 0;
    [SerializeField] private float interval;
    [SerializeField] private int power;

    [SerializeField] private double time;

    [SerializeField] private float range;

    BulletType bulletType = BulletType.Fire;
    [SerializeField] public GameObject bulletPrefab;

    public FireTowerMover(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public void OnEnter()
    {
        interval = GameManager.Instance.playerManager.Interval;
        power = GameManager.Instance.playerManager.Power;
        time = 0;
        targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(gameObject);
        flag = false;
    }

    public void OnUpdate()
    {
        time += GameManager.Instance.timeManager.DeltaTime();
        if (time >= interval)
        {
            CreateBullet(bulletType);
            time -= interval;
        }
        nowAngle += (targetAngle - nowAngle) * 0.1f;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, nowAngle);

    }

    public void OnEnd()
    {

    }

    public void CreateBullet(BulletType type)
    {

        interval = GameManager.Instance.playerManager.Interval;
        power = GameManager.Instance.playerManager.Power;


        if (targetEnemy == null)
        {
            targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(this.gameObject);
            time = 0;
        }
        if (targetEnemy != null)
        {
            var diff = gameObject.transform.position - targetEnemy.transform.position;
            var axis = Vector3.Cross(gameObject.transform.forward, diff);
            targetAngle = Vector3.Angle(new Vector3(0f, -1f, 0f), diff) * (axis.y < 0 ? -1 : 1);


            //var bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.Euler(0, 0, targetAngle)).GetComponent<BulletBase>();
            //bullet.Initialize(power);
        }
    }
}
