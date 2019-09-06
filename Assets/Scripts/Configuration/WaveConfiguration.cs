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
        private GameObject apperEnemyGroup;


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
