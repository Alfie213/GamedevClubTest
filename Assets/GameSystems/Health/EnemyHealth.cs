using UnityEngine;

public class EnemyHealth : HealthBase
{
    protected override void Death()
    {
        Debug.Log("Enemy's death");
        EventBus.EnemyDeath.Publish(transform.position);
    }
}
