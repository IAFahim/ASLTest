using System;
using RunStateMachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

[Serializable]
public partial class RunnerState
{
    public bool startMove;
    public bool pause;
    public bool isTargetReached;

    public UnityEvent onRotateToTarget = new UnityEvent();
    
    private ITargetAble _targetAble;
    private IMoveAble _moveAble;
    private IAnimatable _animatable;
    
    private bool StartMove => startMove;
    private bool PauseMove
    {
        get => pause;
        set
        {
            pause = value;
            _animatable.Pause();
        }
    }

    private bool ResumeMove
    {
        get => !pause;
        set
        {
            pause = !value;
            _animatable.Resume();
        }
    }

    private bool IsTargetReached => isTargetReached;


    public void Init(ITargetAble targetAble, IMoveAble moveAble, IAnimatable animatable)
    {
        _targetAble = targetAble;
        _moveAble = moveAble;
        _animatable = animatable;
        Start();
    }

    private void UpdateAnimation(string animationName)
    {
        _animatable.Play(animationName);
    }

    private void RotateToTarget()
    {
        _targetAble.RotateTowardTarget();
    }

    public void FindNewTarget()
    {
        _targetAble.OnNewTarget();
    }
    
    public void MoveTowardTarget()
    {
        _moveAble.Move();
        isTargetReached = _targetAble.HasTargetReached();
    }
}
