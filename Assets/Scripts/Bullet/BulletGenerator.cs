using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    private List<Transform[]> eachBulletPositions = new List<Transform[]>();
    private GameObject targetEnemy;
    private float interval;
    private int power;
    private float time;
    [SerializeField]  BulletType bulletType;
    [SerializeField]  public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        interval = GameManager.Instance.playerManager.GetInterval();
        power = GameManager.Instance.playerManager.GetPower();
        time = 0;
        bulletType=gameObject.GetComponent<TowerController>().bulletType;
        targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        time += (float)GameManager.Instance.timeManager.DeltaTime();
        if (time >= interval) {
            time -= interval;
            CreateBullet(bulletType);
        }
    }

    public void CreateBullet(BulletType type)
    {
        
        interval = GameManager.Instance.playerManager.GetInterval();
        power = GameManager.Instance.playerManager.GetPower();
        if (targetEnemy != null) {
            targetEnemy = GameManager.Instance.enemyManager.NearestEnemy(this.gameObject);
        }
        var bullet = Instantiate(bulletPrefab, this.transform.position, Quaternion.identity).GetComponent<BulletBase>();

    }
}
