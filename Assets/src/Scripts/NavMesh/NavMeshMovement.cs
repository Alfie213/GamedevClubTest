using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement
{
    private static readonly WaitForSeconds Delay = new WaitForSeconds(0.5f);

    private NavMeshAgent agent;

    private readonly MonoBehaviour monoBehaviour; // Required for StartCoroutine().

    public NavMeshMovement(float speed, NavMeshAgent navMeshAgent, float stoppingDistance, MonoBehaviour monoBehaviour)
    {
        InitNavMeshAgent(navMeshAgent, speed, stoppingDistance);

        this.monoBehaviour = monoBehaviour;
    }

    private void InitNavMeshAgent(NavMeshAgent navMeshAgent, float speed, float stoppingDistance)
    {
        agent = navMeshAgent;

        agent.speed = speed;
        agent.stoppingDistance = stoppingDistance;
        
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
            try
            {
                agent.destination = target.position;
            }
            catch(Exception exception)
            {
                yield break;
            }

            yield return Delay;
        }
    }

    private bool CheckDestinationReached()
    {
        return agent.remainingDistance <= agent.stoppingDistance;
    }
}