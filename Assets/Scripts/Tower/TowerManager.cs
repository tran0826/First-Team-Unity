using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    private float time;
    [SerializeField] private int hp;
    [SerializeField] private int experience;
    private float interval;
    private int power;
    private int totalNum = 1;
    private int currentNum = 0;
    private List<TowerBase> towerList = new List<TowerBase>();
  

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public float GetInterval() {
        return interval;
    }
    public float GetPower()
    {
        return power;
    }

    /*
    public void LevelUp() {
        
    }

    
    public void CreateTower(TowerBase tower) {
        if (currentNum < totalNum)
        {
            towerList.Add(tower);
            currentNum++;
        }
        else {
            Destroy(tower);
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            hp--;//
            //GameManager.Instance.collisionManager.CollisionPlayerToEnemy(enemy);
        }
    }
}
