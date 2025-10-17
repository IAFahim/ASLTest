using System;
using EventDatas.Runtime;
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
    public bool skipedFirst;

    public EventBusIndexData eventBusIndexData; 

    private void OnValidate()
    {
        animator = GetComponent<Animator>();
    }

    public void Start()
    {
        runnerState.Init(this, this, this);
    }

    public void Play()
    {
        runnerState.startMove = true;
    }

    private void Update()
    {
        runnerState.DispatchEvent(RunnerState.EventId.DO);
    }

    public void OnNewTarget()
    {
        NotifyStage();
        target = targets[targetIndex];
        targetIndex = (++targetIndex) % targets.Length;
    }

    private void NotifyStage()
    {
        if (skipedFirst)
        {
            eventBusIndexData.Publish(targetIndex);
        }
        else
        {
            skipedFirst = true;
        }
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

    public bool HasTargetReached()
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
        runnerState.pause = true;
    }

    public void Resume()
    {
        animator.speed = 1;
        runnerState.pause = false;
        animator.Play("running");
    }
}