using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private GameObject targetEnemy;
    private float targetAngle=0;
    private float nowAngle = 0;
    [SerializeField] private float interval;
    [SerializeField] private int power;
    
    [SerializeField] private double time;

    [SerializeField] private float range;
    [SerializeField] BulletType bulletType = BulletType.Fire;
    [SerializeField] public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.towerManager.Born(gameObject);

        interval = GameManager.Instance.playerManager.Interval;
        power = GameManager.Instance.playerManager.Power;
        time = 0;
        targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        time += GameManager.Instance.timeManager.DeltaTime();
        if (time>= interval)
        {
            CreateBullet(bulletType);
            time -= interval;
        }
        nowAngle += (targetAngle - nowAngle) * 0.1f;
        this.transform.rotation = Quaternion.Euler(0, 0, nowAngle);
    }

    public void CreateBullet(BulletType type)
    {

        interval = GameManager.Instance.playerManager.Interval;
        power = GameManager.Instance.playerManager.Power;

        
        if (targetEnemy == null)
        {
            targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(this.gameObject);
            time=0;
        }
        if (targetEnemy != null)
        {
            var diff = this.transform.position - targetEnemy.transform.position;
            var axis = Vector3.Cross(gameObject.transform.forward, diff);
            targetAngle = Vector3.Angle(new Vector3(0f, -1f, 0f), diff) * (axis.y < 0 ? -1 : 1);

            
            var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.Euler(0, 0, targetAngle)).GetComponent<BulletBase>();
            bullet.Initialize(power);
        }
    }
}
