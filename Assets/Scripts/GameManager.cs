﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private double fadeoutTime = 0;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                
                Type t = typeof(GameManager);

                instance = (GameManager)FindObjectOfType(t);
                if (instance == null)
                {
                    Debug.Log(t + "をアタッチしているGameObjectはありません");
                }
            }
            return instance;
        }
    }

    public CollisionManager collisionManager;
    public DamageManager damageManager;
    public TimeManager timeManager;
    public SharedValue sharedValue;
    public TowerManager towerManager;
    public DestroyManager destroyManager;
    public EnemyManager enemyManager;
    public PlayerManager playerManager;
    public PhaseManager phaseManager;
    public WaveManager waveManager;
    public InstallManager installManager;
    public MapManager mapManager;
    public UIManager uiManager;
    


    virtual protected void Awake()
    {
        CheckInstance();
    }

    protected bool CheckInstance()
    {
        if (instance == null)
        {
            instance = this as GameManager;
            return true;
        }else if (Instance == this)
        {
            return true;
        }
        Destroy(this);
        return false;
    }

    // Start is called before the first frame update
    private void Start()
    {
        phaseManager.Initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        phaseManager.UpdateByFrame();
        collisionManager.UpdateByFrame();
        damageManager.UpdateByFrame();
        destroyManager.UpdateByFrame();
        timeManager.UpdateByFrame();
        towerManager.UpdateByFrame();
        enemyManager.UpdateByFrame();
        playerManager.UpdateByFrame();
        waveManager.UpdateByFrame();
        installManager.UpdateByFrame();
        mapManager.UpdateByFrame();
        uiManager.UpdateByFrame();

        if (sharedValue.TransFlag == true)
        {
            if (fadeoutTime >= 3)
            {
                if (sharedValue.NextScene == Scene.GameOver)
                {
                    SceneManager.LoadScene("GameOver");
                }
                else if (sharedValue.NextScene == Scene.GameClear)
                {
                    SceneManager.LoadScene("Result");
                }

            }
            fadeoutTime += timeManager.PauseDeltaTime();
            GameObject.Find("BGM").GetComponent<AudioSource>().volume = (float)((3.0 - fadeoutTime) / 3.0);
        }
    }
}
