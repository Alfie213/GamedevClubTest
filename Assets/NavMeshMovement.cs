using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement
{
    private static readonly WaitForSeconds Delay = new WaitForSeconds(1f);

    private readonly float speed;
    private NavMeshAgent agent;

    private readonly MonoBehaviour monoBehaviour; // Required for StartCoroutine().

    public NavMeshMovement(float speed, NavMeshAgent navMeshAgent, MonoBehaviour monoBehaviour)
    {
        this.speed = speed;
        
        InitNavMeshAgent(navMeshAgent);

        this.monoBehaviour = monoBehaviour;
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

    public void SetTarget(Transform target)
    {
        monoBehaviour.StartCoroutine(TargetChasing(target));
    }

    private IEnumerator TargetChasing(Transform target)
    {
        while (true)
        {
            agent.destination = target.position;
            if (CheckDestinationReached())
                yield break;

            yield return Delay;
        }
    }

    private bool CheckDestinationReached()
    {
        return agent.remainingDistance <= agent.stoppingDistance;
    }
}