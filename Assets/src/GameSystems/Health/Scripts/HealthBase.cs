using System;

public abstract class HealthBase : IDamageable
{
    public Action<int> OnHpChange;
    
    private int maxHp;
    private int currentHp;

    protected HealthBase(int maxHp)
    {
        this.maxHp = maxHp;
        currentHp = maxHp;
    }
    
    protected abstract void Death();
    
    public void GetDamage(int damage)
    {
        currentHp -= damage;
        OnHpChange?.Invoke(currentHp);
        
        if (currentHp <= 0)
            Death();
    }
}