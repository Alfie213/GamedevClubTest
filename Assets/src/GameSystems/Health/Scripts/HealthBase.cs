using UnityEngine;

public abstract class HealthBase : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHp;

    private int currentHp;

    protected abstract void Death();
    
    public void GetDamage(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
            Death();
    }
}