using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public CellInventory[] Cells { get; }

    private readonly HashSet<ItemData.ItemType> itemsTypes;
    
    //test
    private InventoryData data;
    //test

    private void Init()
    {
        Item.OnTake += TryAdd;
        EventBus.ItemDeleteButtonOnClick.Subscribe(Handle_ItemDeleteButtonOnClick);
    }

    private void DeInit()
    {
        Item.OnTake -= TryAdd;
        EventBus.ItemDeleteButtonOnClick.Unsubscribe(Handle_ItemDeleteButtonOnClick);
    }

    public Inventory(InventoryData inventoryData)
    {
        CheckInventoryData(inventoryData);

        data = inventoryData;
        Cells = new CellInventory[data.Cells.Length];
        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i] = new CellInventory(data.Cells[i]);
        }
        
        itemsTypes = new HashSet<ItemData.ItemType>();
        foreach (CellInventoryData cell in inventoryData.Cells)
        {
            if (!cell.IsEmpty)
                itemsTypes.Add(cell.Type);
        }
        
        Init();
    }

    /// <summary>
    /// Trying to add item in inventory.
    /// </summary>
    private void TryAdd(Item item, out bool added)
    {
        if (!TryChangeAmount(item) && !TryPut(item))
        {
            Debug.LogWarning("There are no space for this item!");
            added = false;
            return;
        }
        itemsTypes.Add(item.ItemData.Type);
        added = true;
    }

    /// <summary>
    /// Trying to change amount of item in existing cell instead of occupation of free cell.
    /// </summary>
    private bool TryChangeAmount(Item item)
    {
        if (item.ItemData.Stackable)
        {
            if (itemsTypes.Contains(item.ItemData.Type))
            {
                foreach (CellInventory cell in Cells)
                {
                    if (cell.Data.Type == item.ItemData.Type)
                    {
                        if (!cell.IsFull)
                        {
                            cell.Add(item);
                            // Debug.Log("Changed amount.");
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Trying to find free cell in inventory and put an Item there.
    /// </summary>
    private bool TryPut(Item item)
    {
        foreach (var cell in Cells)
        {
            if (cell.IsEmpty)
            {
                cell.Add(item);
                // Debug.Log("Added without changing amount.");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Decrease item amount in inventory.
    /// </summary>
    public bool DecreaseAmount(int indexOfCell, int amount)
    {
        return Cells[indexOfCell].DecreaseAmount(amount);
    }
    
    /// <summary>
    /// Removes item from inventory.
    /// </summary>
    public void Remove(Item item)
    {
        if (itemsTypes.Contains(item.ItemData.Type))
        {
            foreach (CellInventory cell in Cells)
            {
                if (cell.Data.Type == item.ItemData.Type)
                {
                    cell.Clear();
                    // if (cell.IsEmpty) itemsTypes.Remove(item.GetType()); Need to rebuild logic.
                    return;
                }
            }
        }
    }
    
    /// <summary>
    /// Removes item from inventory.
    /// </summary>
    public void ClearCell(int indexOfCell)
    {
        Cells[indexOfCell].Clear();
        // itemsTypes.Remove(item.GetType()); Need to rebuild logic.
    }

    #region Unused Swap
    /// <summary>
    /// Swaps the values of two CellInventory by reference.
    /// </summary>
    public void SwapValuesOfCells(ref CellInventory firstCell, ref CellInventory secondCell)
    {
        (firstCell, secondCell) = (secondCell, firstCell);
    }
    #endregion

    /// <summary>
    /// Swaps the values of two CellInventory by index.
    /// </summary>
    public void SwapValuesOfCells(int firstIndex, int secondIndex)
    {
        (Cells[firstIndex], Cells[secondIndex]) = (Cells[secondIndex], Cells[firstIndex]);
        (data.Cells[firstIndex], data.Cells[secondIndex]) = (data.Cells[secondIndex], data.Cells[firstIndex]);
        // Just change order of data (SO). Perfect to not change the order, but to change the values.
    }

    /// <summary>
    /// Returns CellInventory by index.
    /// </summary>
    public CellInventory GetCell(int index)
    {
        return Cells[index];
    }

    private void CheckInventoryData(InventoryData inventoryData)
    {
        if (inventoryData.Cells.Length <= 0) throw new ArgumentException("Wrong length of Inventory!");
    }

    private void Handle_ItemDeleteButtonOnClick(int indexOfCell)
    {
        ClearCell(indexOfCell);
    }
}
