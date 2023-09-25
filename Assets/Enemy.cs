using UnityEngine;

[RequireComponent(typeof(EnemyHealth), typeof(Collider2D))]
public class Enemy : MonoBehaviour
{
    private EnemyHealth health;
    private Collider2D col;

    private NavMeshMovement movement;

    private void Awake()
    {
        health = GetComponent<EnemyHealth>();
        
        InitCollider();

        movement = GetComponentInChildren<NavMeshMovement>();
    }

    private void InitCollider()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("1");
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            Debug.Log("2");
            movement.SetDestination(other.transform.position);
        }
    }
}
