using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int hp;
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
            GameManager.Instance.collisionManager.CollisionEnemyToPlayer(enemy);
        }
    }

    public int GetHp()
    {
        return hp;
    }

    public void HitEnemy(int damage)
    {
        hp -= damage;
    }
}
