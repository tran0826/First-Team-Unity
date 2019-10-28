﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private Queue<EnemyBulletPair> enemyBulletCoList = new Queue<EnemyBulletPair>();
    private Queue<EnemyPlayerPair> enemyPlayerCoList = new Queue<EnemyPlayerPair>();

    DestroyManager destroyManager;
    EnemyManager enemyManager;
    PlayerManager playerManager;

    SharedValue sharedValue;

    [SerializeField]
    private AudioClip playerDamage;
    [SerializeField]
    private AudioClip playerDamageVoice;
    [SerializeField]
    private AudioClip gameOver;


    private void Awake()
    {
        destroyManager = GameManager.Instance.destroyManager;
        enemyManager = GameManager.Instance.enemyManager;
        playerManager = GameManager.Instance.playerManager;
        sharedValue = GameManager.Instance.sharedValue;

    }


    public void SetCoList(List<EnemyBulletPair> ebList,List<EnemyPlayerPair> epList)
    {
        foreach(var enemyBulletPair in ebList)
        {
            enemyBulletCoList.Enqueue(enemyBulletPair);
        }
        foreach(var enemyPlayerPair in epList)
        {
            enemyPlayerCoList.Enqueue(enemyPlayerPair);
        }
    }

    public void UpdateByFrame()
    {
        ExecEnemyPlayerProcess();
        ExecEnemyBulletProcess();
    }


    private void ExecEnemyPlayerProcess()
    {
        if (enemyPlayerCoList.Count == 0) return;
        foreach(EnemyPlayerPair pair in enemyPlayerCoList)
        {
            float enemyPower = pair.enemy.Power;
            PlayerDamaged(pair.player,enemyPower);
            EnemyDead(pair.enemy);
            if (pair.player.Hp <= 0)
            {
                PlayerDead(pair.player);
            }
        }
        enemyPlayerCoList.Clear();
    }

    private void ExecEnemyBulletProcess()
    {
        if (enemyBulletCoList.Count == 0) return;
        foreach (EnemyBulletPair pair in enemyBulletCoList)
        {
            int bulletPower = pair.bullet.Power;

            DisplayHitEffect(pair.bullet.transform.position);
            if (pair.bullet.CanDestroyOnCollision)
            {
                destroyManager.AddDestroyList(pair.bullet.gameObject);
            }
            pair.enemy.HitBullet(bulletPower);
            
            if (pair.enemy.Hp <= 0)
            {
                GameManager.Instance.playerManager.Experience += pair.enemy.Experience;
                EnemyDead(pair.enemy);
            }
            
        }
        enemyBulletCoList.Clear();
    }

    private void PlayerDamaged(PlayerController player,float damage)
    {
        player.HitEnemy(damage);
        GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(playerDamage);
        GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(playerDamageVoice);
    }

    private void PlayerDead(PlayerController player)
    {
        GameManager.Instance.GetComponent<AudioSource>().PlayOneShot(gameOver);
        GameManager.Instance.timeManager.Pause();
        GameManager.Instance.sharedValue.TransFlag = true;
        GameManager.Instance.sharedValue.NextScene = Scene.GameOver;
    }

    private void EnemyDead(EnemyController enemy)
    {
        enemyManager.Kill(enemy.gameObject);
        destroyManager.AddDestroyList(enemy.gameObject);
    }

    private void DisplayHitEffect(Vector3 pos)
    {

    }


}
