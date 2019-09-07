using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    private GameObject targetEnemy;
    private Vector3 targetPos;
    [SerializeField] private float interval;
    [SerializeField] private int power;
    [SerializeField] private double time;
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
    }

    public void CreateBullet(BulletType type)
    {

        interval = GameManager.Instance.playerManager.Interval;
        power = GameManager.Instance.playerManager.Power;
        if (targetEnemy != null)
        {
            targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(this.gameObject);
            targetPos = targetEnemy.transform.position;
        }

        var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity).GetComponent<BulletBase>();
        bullet.Initialize(power, targetPos);
    }
}
