using System;
using RunStateMachine;
using UnityEngine;

public class Runner : MonoBehaviour, ITargetAble, IMoveAble, IAnimatable
{
    public RunnerState runnerState;
    [SerializeField] private Animator animator;
    [SerializeField] private float lastAnimationSpeed =1 ;
    
    [SerializeField] Transform[] targets;
    [SerializeField] Transform target;
    [SerializeField] int targetIndex;
    [SerializeField] Vector3 direction;
    public float rangeSq = 0.01f;
    public float moveSpeed = 1;

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        runnerState.Init(this, this, this);
    }

    private void Update()
    {
        runnerState.DispatchEvent(RunnerState.EventId.DO);
    }

    public void GetNewTarget()
    {
        target = targets[targetIndex];
        targetIndex = (++targetIndex) % targets.Length;
    }

    public void RotateTowardTarget()
    {
        SetupDirection();
        transform.LookAt(direction);
    }
    
    public void Move()
    {
        SetupDirection();
        transform.Translate(direction * (moveSpeed * Time.deltaTime), Space.World);
    }

    private void SetupDirection()
    {
        var diff = target.position - transform.position;
        direction = diff.normalized;
    }

    public bool IsTargetReached()
    {
        var diff = target.position - transform.position;
        return Mathf.Abs(diff.sqrMagnitude) < rangeSq;
    }

    public void Play(string clipName)
    {
        if(String.IsNullOrEmpty(clipName)){ return; }
        animator.Play(clipName);
    }

    public void Pause()
    {
        lastAnimationSpeed = animator.speed;
        animator.speed = 0;
    }

    public void Resume()
    {
        animator.speed = lastAnimationSpeed;
    }
}