using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hp;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    // Start is called before the first frame update
    void Awake()
    {
        GameManager.Instance.sharedValue.Hp = hp;
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
            GameManager.Instance.collisionManager.CollisionEnemyToPlayer(enemy,this);
            Debug.Log("Collision EnemyToPlayer");
        }
    }
    

    public void HitEnemy(float damage)
    {
        hp -= damage;
        GameManager.Instance.sharedValue.Hp = hp;
    }
}
