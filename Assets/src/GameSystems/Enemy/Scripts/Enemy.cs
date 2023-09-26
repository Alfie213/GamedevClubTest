using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider2D), typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public EnemyHealth Health => health;
    
    [SerializeField] private int maxHp;
    [SerializeField] private float speed;
    
    [Header("Player chasing settings")]
    [SerializeField] private float stoppingDistance;
    
    private Collider2D col;

    private EnemyHealth health;
    private NavMeshMovement movement;

    private void Awake()
    {
        InitCollider();
        
        health = new EnemyHealth(maxHp, transform.position);
        movement = new NavMeshMovement(speed, GetComponent<NavMeshAgent>(), stoppingDistance, this);
    }

    private void OnEnable()
    {
        health.OnDeath += Handle_OnDeath;
    }

    private void OnDisable()
    {
        health.OnDeath -= Handle_OnDeath;
    }

    private void InitCollider()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out PlayerMovement playerMovement)) // Component may be changed.
        {
            movement.SetTarget(other.transform);
        }
        else if (other.TryGetComponent<Projectile>(out Projectile projectile))
        {
            health.GetDamage(projectile.Damage);
        }
    }

    private void Handle_OnDeath()
    {
        Destroy(gameObject);
    }
}
