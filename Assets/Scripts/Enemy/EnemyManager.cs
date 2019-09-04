﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private HashSet<GameObject> EnemyUnits = new HashSet<GameObject>();
    private Queue<GameObject> bornQueue = new Queue<GameObject>();
    private Queue<GameObject> deadQueue = new Queue<GameObject>();

    public void Born(List<GameObject> borns)
    {
        foreach (var born in borns)
        {
            Born(born);
        }
    }
    public void Born(GameObject born)
    {
        if (born.GetComponent<EnemyController>() != null)
        {
            bornQueue.Enqueue(born);
        }
    }

    public void Kill(List<GameObject> kills)
    {
        foreach (var kill in kills)
        {
            Kill(kill);
        }
    }
    public void Kill(GameObject kill)
    {
        if (kill.GetComponent<EnemyController>())
        {
            deadQueue.Enqueue(kill);
        }
    }

    private void BornQueueProcess()
    {
        while (0 < bornQueue.Count)
        {
            EnemyUnits.Add(bornQueue.Dequeue());
        }
    }
    private void KillQueueProcess()
    {
        while (0 < deadQueue.Count)
        {
            EnemyUnits.Remove(deadQueue.Dequeue());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void UpdateByFrame()
    {
        BornQueueProcess();
        KillQueueProcess();
    }

    public GameObject NearestEnemy(GameObject tower)
    {
        float nearest = Mathf.Infinity;
        GameObject nearEnemy = null;

        Vector3 towerPos = tower.transform.position;

        foreach (GameObject enemy in EnemyUnits)
        {
            if (enemy == null) continue;
            Vector3 distVec = towerPos - enemy.transform.position;
            float dist = distVec.magnitude;
            if (nearest > dist)
            {
                nearest = dist;
                nearEnemy = enemy;
            }
        }
        return nearEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
