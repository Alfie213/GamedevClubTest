using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour
{
    private PlayerHealth health;
    private Collider2D col;

    private void Awake()
    {
        health = new PlayerHealth(100);
        InitCollider();
    }

    private void InitCollider()
    {
        col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.TryGetComponent<Bullet>(out Bullet bullet))
        // {
        //     health.GetDamage(bullet.BulletData.Damage);
        // }
    }
}
