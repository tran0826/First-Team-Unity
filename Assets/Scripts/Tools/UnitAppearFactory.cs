using System.Collections.Generic;
using UnityEngine;
using Model;

namespace Tools
{
    public class UnitAppearFactory
    {
        public static UnitAppearer CreateFromConfiguration(GameObject appearRoot,WaveConfiguration waveConfiguration)
        {
            List<WaveAppearModel> waveAppearModels = new List<WaveAppearModel>();
            foreach(var appearConfiguration in waveConfiguration.AppearConfigurations)
            {
                waveAppearModels.Add(new WaveAppearModel(appearConfiguration.AppearTime, appearConfiguration.AppearEnemyGroup));
            }
            return new UnitAppearer(appearRoot, new WaveAppearsModel(waveAppearModels));
        }
    }
}