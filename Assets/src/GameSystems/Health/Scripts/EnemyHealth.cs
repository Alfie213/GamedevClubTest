using UnityEngine;

public class EnemyHealth : HealthBase
{
    private readonly Vector3 enemyPosition;

    public EnemyHealth(int maxHp, Vector3 enemyPosition) : base(maxHp)
    {
        this.enemyPosition = enemyPosition;
    }
    
    protected override void Death()
    {
        base.Death();
        EventBus.EnemyDeath.Publish(enemyPosition);
    }
}
