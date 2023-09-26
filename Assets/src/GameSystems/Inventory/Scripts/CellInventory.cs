using UnityEngine;

public class CellInventory
{
    // Public properties.
    public bool IsEmpty => Data.IsEmpty;
    
    public bool IsFull => Data.CurrentAmount == Data.MaxAmount;
    
    // Data.
    public CellInventoryData Data { get; private set; }
    
    public CellInventory(CellInventoryData data)
    {
        Data = data;
    }
    
    public void Add(Item item)
    {
        if (IsEmpty)
            Init(item);
        Data.CurrentAmount++;
    }

    private void Init(Item item)
    {
        Data.ItemData = item.ItemData;
        Data.Type = item.ItemData.Type;
        Data.MaxAmount = item.ItemData.MaxAmount;
    }

    private void DeInit()
    {
        Data.ItemData = null;
        Data.CurrentAmount = 0;
        Data.MaxAmount = 0;
    }

    public void Clear()
    {
        DeInit();
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
