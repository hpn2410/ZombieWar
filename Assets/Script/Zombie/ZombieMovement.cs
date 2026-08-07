using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveTo(Transform target)
    {
        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    public void Stop()
    {
        agent.isStopped = true;
    }
}