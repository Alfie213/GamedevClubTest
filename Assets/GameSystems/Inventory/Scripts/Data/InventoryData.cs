using UnityEngine;

[CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/InventoryData")]
public class InventoryData : ScriptableObject
{
    public CellInventoryData[] Cells;
}