﻿using System.Collections;
using System.Collections.Generic;
using Tools;
using Parameter;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    [SerializeField]
    private GameObject appearRoot;

    private UnitAppearer currentUnitAppearer;

    private double prevEndTime = 0f;
    public void StartWave(WaveParameter waveParameter)
    {
        currentUnitAppearer = UnitAppearFactory.CreateFromConfiguration(appearRoot, waveParameter.WaveConfiguration);
    }

    public void UpdateByFrame()
    {
        if (currentUnitAppearer != null)
        {
            var elapsedTime = GameManager.Instance.timeManager.AbsoluteTime();
            var searchAppearModel = currentUnitAppearer.AppearBy(elapsedTime - prevEndTime);
            foreach(GameObject wave in searchAppearModel)
            {
                EnemyController[] childlen = wave.GetComponentsInChildren<EnemyController>();
                foreach(EnemyController child in childlen)
                {
                    GameManager.Instance.enemyManager.Born(child.gameObject);
                }
            }
        }
    }

    public bool IsFinishWave()
    {
        
        if (currentUnitAppearer.IsAllAppeared)
        {/*
            if (GameManager.Instance.enemyManager.IsBossExist())
            {
                return false;
            }
            else
            {
                return true;
            }
            */
            return false;
        }
        return false;
    }

    public void FinishWave()
    {
        prevEndTime = GameManager.Instance.timeManager.AbsoluteTime();
    }
}
