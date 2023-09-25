public abstract class HealthBase : IDamageable
{
    private int maxHp;
    private int currentHp;

    protected HealthBase(int maxHp)
    {
        this.maxHp = maxHp;
        this.currentHp = maxHp;
    }
    
    protected abstract void Death();
    
    public void GetDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
            Death();
    }
}