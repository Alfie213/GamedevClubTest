using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    [Header("Health settings")]
    [SerializeField] private int health;
    [SerializeField] private HealthBar healthBar;
    
    private PlayerHealth playerHealth;
    private Collider2D col;

    private void Awake()
    {
        playerHealth = new PlayerHealth(health);
        InitCollider();
        
        healthBar.SetTrackableHealth(playerHealth);
    }

    private void OnEnable()
    {
        playerHealth.OnDeath += Handle_OnDeath;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= Handle_OnDeath;
    }

    private void InitCollider()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            playerHealth.GetDamage(enemy.Damage);
        }
    }

    private void Handle_OnDeath()
    {
        Destroy(gameObject);
    }
}
