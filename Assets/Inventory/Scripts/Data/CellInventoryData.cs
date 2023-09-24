using UnityEngine;

[CreateAssetMenu(fileName = "CellInventoryData", menuName = "Inventory/CellInventoryData")]
public class CellInventoryData : ScriptableObject
{
    public ItemData ItemData;
    public ItemData.ItemType Type;
    public int CurrentAmount;
}