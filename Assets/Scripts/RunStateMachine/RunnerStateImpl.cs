using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public partial class RunnerState
{
    public bool isTargetReached;
    public UnityEvent<string> onUpdateAnimation = new UnityEvent<string>();
    public UnityEvent onRotateToTarget = new UnityEvent();
    public UnityEvent onMoveTowardTarget = new UnityEvent();
    
    private void UpdateAnimation(string animationName)
    {
        Debug.Log($"UpdateAnimation called with: {animationName}");
        onUpdateAnimation.Invoke(animationName);
    }

    private void RotateToTarget()
    {
        Debug.Log("RotateToTarget called");
        onRotateToTarget.Invoke();
    }

    private void MoveTowardTarget()
    {
        Debug.Log("MoveTowardTarget called");
        onMoveTowardTarget.Invoke();
    }

    private bool IsTargetReached => isTargetReached;
}
