namespace RunStateMachine
{
    public interface ITargetAble
    {
        public void OnNewTarget();
        public bool HasTargetReached();
        public void RotateTowardTarget();
    }
}