using UnityEngine;

public class PlayerHealth : HealthBase
{
    protected override void Death()
    {
        Debug.LogWarning("Player's death!");
    }
}
