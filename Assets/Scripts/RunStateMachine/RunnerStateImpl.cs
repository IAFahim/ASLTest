using System;
using RunStateMachine;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public partial class RunnerState
{
    public bool startMove;
    public bool pause;
    public bool isTargetReached;

    public UnityEvent<string> onUpdateAnimation = new UnityEvent<string>();
    public UnityEvent onRotateToTarget = new UnityEvent();

    [SerializeField] Animator animator;
    
    private ITargetAble _targetAble;
    private IMoveAble _moveAble;
    
    private bool StartMove => startMove;
    private bool PauseMove => pause;
    private bool ResumeMove => !pause;
    private bool IsTargetReached => isTargetReached;


    public void Init(ITargetAble targetAble, IMoveAble moveAble)
    {
        _targetAble = targetAble;
        _moveAble = moveAble;
        Start();
    }

    private void UpdateAnimation(string animationName)
    {
        animator.Play(animationName);
        onUpdateAnimation.Invoke(animationName);
    }

    private void RotateToTarget()
    {
        _targetAble.RotateTowardTarget();
    }

    public void FindNewTarget()
    {
        _targetAble.GetNewTarget();
    }
    
    public void MoveTowardTarget()
    {
        _moveAble.Move();
        isTargetReached = _targetAble.IsTargetReached();
    }
}
