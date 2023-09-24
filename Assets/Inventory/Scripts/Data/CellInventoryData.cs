using UnityEngine;

[CreateAssetMenu(fileName = "CellInventoryData", menuName = "Inventory/CellInventoryData")]
public class CellInventoryData : ScriptableObject
{
    public bool IsEmpty => ItemData is null;
    
    public ItemData ItemData;
    public ItemData.ItemType Type;
    public int CurrentAmount;
}