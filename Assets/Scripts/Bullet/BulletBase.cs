﻿using UnityEngine;
using UnityEngine.Events;


public abstract class BulletBase : MonoBehaviour
{
    [SerializeField]
    private int power;
    [SerializeField]
    protected float speed;
    protected Vector3 direction;
    private Renderer bulletRenderer;
    
    public int Power { get { return power; } protected set { power = value; } }

    public virtual bool CanDestroyOnCollision { get; protected set; } = true;

    void Awake()
    {
        bulletRenderer = GetComponent<Renderer>();
    }

    public abstract void Move();

    void Update()
    {
        Move();

    }
    public abstract void Initialize(int power);

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.gameObject.GetComponent<EnemyController>();
        if (enemy != null)
        {
            GameManager.Instance.collisionManager.CollisionBulletToEnemy(enemy,this);
            return;
        }
    }
}
