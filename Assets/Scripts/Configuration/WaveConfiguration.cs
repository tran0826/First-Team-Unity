using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName ="ScriptableObject/WaveConfiguration")]

public class WaveConfiguration : ScriptableObject
{
    [Serializable]
    public class AppearConfiguration {
        [SerializeField]
        private GameObject appearEnemyGroup;

        [SerializeField]
        private double appearTime;

        public GameObject AppearEnemyGroup
        {
            get { return appearEnemyGroup; }
        }

        public double AppearTime
        {
            get { return appearTime; }
        }
    }

    [FormerlySerializedAs("appearConfigurations")]
    [SerializeField]
    private List<AppearConfiguration> appearConfigurations;

    public List<AppearConfiguration> AppearConfigurations
    {
        get { return appearConfigurations; }
    }
}
