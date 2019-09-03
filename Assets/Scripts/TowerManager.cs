using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    private float time;
    [SerializeField] private int hp;
    [SerializeField] private int experience;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
