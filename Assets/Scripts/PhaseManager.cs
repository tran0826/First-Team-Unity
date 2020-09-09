﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Model;
using Phase;
using Parameter;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    [SerializeField]
    private GameConfiguration gameConfiguration;

    private IPhase currentPhase = null;
    public void Initialize() {
        var waveParameters = gameConfiguration.WaveConfigurations.Select(waveConfiguration => new WaveParameter()
        {
            WaveConfiguration = waveConfiguration
        });
        ChangePhase(new WavePhase(new GameModel(waveParameters.ToList())));
    }

    public void UpdateByFrame()
    {
        if (currentPhase == null)
        {
            return;
        }
        if (currentPhase.CanTransit())
        {
            ChangePhase(currentPhase.Transit());
        }
        currentPhase.OnUpdate();
    }

    private void ChangePhase(IPhase nextPhase)
    {
        if (currentPhase != null)
        {
            currentPhase.OnExit();
        }
        currentPhase = nextPhase;
        nextPhase.OnEnter();
    }

    public void ForceTransitGameOber()
    {
        
    }

    public bool IsGameFinish()
    {


        return false;
    }


}
