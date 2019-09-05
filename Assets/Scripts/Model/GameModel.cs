using System.Collections.Generic;
using Parameter;


namespace Model
{
    public class GameModel
    {
        private List<WaveParameter> waveParameters;

        private int currentWaveIndex = 0;

        public WaveParameter CurrentWaveParameter
        {
            get { return waveParameters[currentWaveIndex]; }
        }

        public bool HasNext()
        {
            return currentWaveIndex < waveParameters.Count;
        }

        public void Next()
        {
            currentWaveIndex++;
            if (currentWaveIndex >= waveParameters.Count)
            {
                currentWaveIndex = waveParameters.Count;
            }
        }

        public GameModel(List<WaveParameter> waveParameters)
        {
            this.waveParameters = waveParameters;
        }



    }
}