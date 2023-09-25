using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private NavMeshAgent agent;
    
    private void Awake()
    {
        InitAgent();
    }

    private void InitAgent()
    {
        agent = GetComponent<NavMeshAgent>();

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
