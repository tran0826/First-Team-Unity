﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public enum MoveType
    {
        Round,
        SkyStraight
    }

    [SerializeField] MoveType moveType;

    [SerializeField] float speed;

    //private
    private float time;
    [SerializeField] private int hp;
    [SerializeField] private int experience;

    private IEnemyMover currentEnemyMover = null;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        if (moveType == MoveType.Round)
        {
            currentEnemyMover = new RoundEnemyMover(gameObject, speed);
            currentEnemyMover.OnEnter();
        }
        else if (moveType == MoveType.SkyStraight)
        {

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemyMover != null)
        {
            currentEnemyMover.OnUpdate();
        }
        time += (float)GameManager.Instance.timeManager.DeltaTime();
    }

    public void HitBullet(int damage)
    {
        hp -= damage;
    }

    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        
    }

}
