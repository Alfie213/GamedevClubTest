using UnityEngine;

public static class EventBus
{
    public static readonly CustomAction<Vector3> EnemyDeath = new CustomAction<Vector3>();
    
    public static readonly CustomAction<int> InventoryCellClick = new CustomAction<int>();
    public static readonly CustomAction InventoryUiOnDisable = new CustomAction();
    public static readonly CustomAction<int> ItemDeleteButtonOnClick = new CustomAction<int>();
    public static readonly CustomAction InventoryOnClearCell = new CustomAction();

}