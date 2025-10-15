using RunStateMachine;
using UnityEngine;

public class Runner : MonoBehaviour, ITargetAble, IMoveAble
{
    public RunnerState runnerState;
    [SerializeField] Transform[] targets;
    [SerializeField] Transform target;
    [SerializeField] int targetIndex;
    [SerializeField] Vector3 direction;
    public float rangeSq = 0.1f;
    public float speed;

    public void Start()
    {
        runnerState.Init(this, this);
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
        transform.Translate(direction * (speed * Time.deltaTime), Space.World);
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
}