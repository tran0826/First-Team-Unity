using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Model
{
    public class WaveAppearsModel
    {
        public List<WaveAppearModel> WaveAppearModels { get; private set; }

        public WaveAppearsModel(List<WaveAppearModel> waveAppearModels)
        {
            this.WaveAppearModels = waveAppearModels;
        }

        public List<WaveAppearModel> SearchAppearModel(double elapsedTime)
        {
            List<WaveAppearModel> appearModels = new List<WaveAppearModel>();
            foreach(var waveAppearModel in WaveAppearModels)
            {
                if (waveAppearModel.CanAppear(elapsedTime))
                {
                    appearModels.Add(waveAppearModel);
                }
            }
            return appearModels;
        }

        public bool IsAllAppeard
        {
            get
            {
                return WaveAppearModels.All(model => model.IsAppeared);
            }
        }
    }
}