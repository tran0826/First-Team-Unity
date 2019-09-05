using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName ="ScriptableObject/WaveConfiguration")]

public class WaveConfiguration : ScriptableObject
{
    [SerializeField]
    public class AppearConfiguration {
        private double appearTime;

        [SerializeField]
        private GameObject apperEnemyGroup;

        public double AppearTime
        {
            get { return appearTime; }
        }

        public GameObject AppearEnemyGroup
        {
            get { return AppearEnemyGroup; }
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
