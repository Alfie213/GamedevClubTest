using UnityEngine;

public class PlayerHealth : HealthBase
{
    public PlayerHealth(int maxHp) : base(maxHp)
    {
    }

    protected override void Death()
    {
        base.Death();
        Debug.LogWarning("Player's death!");
    }
}
