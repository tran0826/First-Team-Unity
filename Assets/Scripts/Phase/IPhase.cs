namespace Phase
{
    public interface IPhase
    {
        void OnEnter();
        void OnUpdate();
        void OnExit();
        bool CanTransit();
        IPhase Transit();
    }
}