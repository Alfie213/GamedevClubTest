
public class EnemyHealth : HealthBase
{
    public EnemyHealth(int maxHp) : base(maxHp)
    { }
    
    protected override void Death()
    {
        base.Death();
    }
}
