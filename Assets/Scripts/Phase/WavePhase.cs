using Parameter;
using Model;

namespace Phase
{
    public class WavePhase : IPhase
    {
        private GameModel gameModel;

        public WavePhase(GameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        public void OnEnter()
        {
            GameManager.Instance.waveManager.StartWave(gameModel.CurrentWaveParameter);
        }

        public void OnUpdate()
        {

        }

        public void OnExit()
        {
            GameManager.Instance.waveManager.FinishWave();
        }

        public bool CanTransit()
        {
            return GameManager.Instance.waveManager.IsFinishWave();
        }

        public IPhase Transit()
        {
            if (!gameModel.HasNext())
            {
                return new GameClearPhase();
            }
            gameModel.Next();
            return new WavePhase(gameModel);
        }



    }
}