using UnityEngine;

public static class EventBus
{
    public static readonly CustomAction<Vector3> EnemyDeath = new CustomAction<Vector3>();
}