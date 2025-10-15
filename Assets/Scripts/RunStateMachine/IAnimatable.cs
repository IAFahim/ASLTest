namespace RunStateMachine
{
    public interface IAnimatable
    {
        public void Play(string clipName);
        public void Pause();
        public void Resume();
    }
}