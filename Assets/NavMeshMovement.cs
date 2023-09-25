using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement
{
    private readonly float speed;
    private NavMeshAgent agent;

    public NavMeshMovement(float speed, NavMeshAgent navMeshAgent)
    {
        this.speed = speed;
        
        InitNavMeshAgent(navMeshAgent);
    }

    private void InitNavMeshAgent(NavMeshAgent navMeshAgent)
    {
        agent = navMeshAgent;

        agent.speed = speed;
        agent.autoBraking = false;
        agent.updateRotation = false;
        agent.angularSpeed = 0f;
        agent.updateUpAxis = false;
    }

    public void SetDestination(Vector3 destination)
    {
        agent.destination = destination;
    }
}
