using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class WaveAppearModel
    {
        public double AppearTime { get; private set; }
        
        public GameObject AppearEnemyGroup { get; private set; }

        public bool IsAppeared { get; private set; }

        public WaveAppearModel(double appearTime,GameObject appearEnemyGroup)
        {
            this.AppearTime = appearTime;
            this.AppearEnemyGroup = appearEnemyGroup;
            this.IsAppeared = false;
        }

        public bool CanAppear(double elapsedTime)
        {
            if (IsAppeared)
            {
                return false;
            }
            if (AppearTime > elapsedTime)
            {
                return false;
            }
            return true;
        }

        public void Appear()
        {
            IsAppeared = true;
        }

    }
}