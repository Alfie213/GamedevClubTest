using System;

public abstract class HealthBase : IDamageable
{
    public Action<int> OnHpChange;
    public Action OnDeath;
    
    private int maxHp;
    private int currentHp;

    private bool isDead;

    protected HealthBase(int maxHp)
    {
        this.maxHp = maxHp;
        currentHp = maxHp;
    }

    protected virtual void Death()
    {
        OnDeath?.Invoke();
    }
    
    public void GetDamage(int damage)
    {
        currentHp -= damage;
        OnHpChange?.Invoke(currentHp);
        
        if (currentHp <= 0 && !isDead)
        {
            isDead = true;
            Death();
        }
    }
}