using UnityEngine;

public class Runner : MonoBehaviour
{
    public RunnerState runnerState;

    private void Update()
    {
        runnerState.DispatchEvent(RunnerState.EventId.DO);
    }
}
