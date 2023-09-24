using UnityEngine;

public class CellInventory
{
    // Public properties.
    public bool IsEmpty => Data.IsEmpty;
    
    public bool IsFull => Data.CurrentAmount == maxAmount;
    
    // Data.
    public CellInventoryData Data { get; private set; }

    // Private variables.
    private int maxAmount = 1;

    public CellInventory()
    {
        Data = null;
    }
    
    public CellInventory(CellInventoryData data)
    {
        Data = data;
    }
    
    public void Add(Item item)
    {
        if (Data.CurrentAmount == 0)
        {
            Init(item);
        }
        Data.CurrentAmount++;
    }

    private void Init(Item item)
    {
        Data.Type = item.ItemData.Type;
        Data.ItemData = item.ItemData;
    }

    private void DeInit()
    {
        Data.ItemData = null;
        Data.CurrentAmount = 0;
        maxAmount = 1;
    }

    public bool DecreaseAmount(int amount)
    {
        bool success = false;
        int difference = Data.CurrentAmount - amount;
        if (difference == 0)
        {
            Data.CurrentAmount -= amount;
            success = true;
            DeInit();
            return success;
        }
        else if (difference < 0)
        {
            Debug.LogWarning("Difference is negative!");
            success = false;
            return success;
        }
        else
        {
            Data.CurrentAmount -= amount;
            success = true;
            return success;
        }
    }
}
