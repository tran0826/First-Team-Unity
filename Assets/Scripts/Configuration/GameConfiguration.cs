using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


[CreateAssetMenu(menuName ="ScriptableObject/GameConfiguration")]
public class GameConfiguration : ScriptableObject
{
    [SerializeField]
    private List<WaveConfiguration> waveConfigurations;

    public List<WaveConfiguration> WaveConfigurations
    {
        get { return waveConfigurations; }
    }

}
