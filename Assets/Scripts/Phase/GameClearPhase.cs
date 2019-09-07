using Parameter;
using Tools;
using UnityEngine.SceneManagement;

namespace Phase
{
    public class GameClearPhase : IPhase
    {
        public GameClearPhase()
        {

        }

        public void OnEnter()
        {

        }
        public void OnUpdate()
        {

        }
        public void OnExit()
        {

        }
        public bool CanTransit()
        {
            return false;
        }

        public IPhase Transit()
        {
            return null;
        }
    }
}