namespace RunStateMachine
{
    public interface ITargetAble
    {
        public void GetNewTarget();
        public bool IsTargetReached();
        public void RotateTowardTarget();
    }
}