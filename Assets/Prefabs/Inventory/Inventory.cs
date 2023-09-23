using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    public CellInventory[] Cells { get; }

    private readonly List<Type> itemsTypes;
    
    //test
    private InventoryData data;
    //test

    private void Init()
    {
        ItemBase.OnTake += TryAdd;
    }

    private void DeInit()
    {
        ItemBase.OnTake -= TryAdd;
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
        itemsTypes = new List<Type>();
        
        Init();
    }

    /// <summary>
    /// Trying to add itemBase in inventory.
    /// </summary>
    private void TryAdd(ItemBase itemBase, out bool added)
    {
        if (!TryChangeAmount(itemBase) && !TryPut(itemBase))
        {
            Debug.LogWarning("There are no space for this itemBase!");
            added = false;
            return;
        }
        itemsTypes.Add(itemBase.GetType());
        added = true;
    }

    /// <summary>
    /// Trying to change amount of itemBase in existing cell instead of occupation of free cell.
    /// </summary>
    private bool TryChangeAmount(ItemBase itemBase)
    {
        if (itemBase.ItemData.Stackable)
        {
            if (itemsTypes.Contains(itemBase.GetType()))
            {
                foreach (CellInventory cell in Cells)
                {
                    if (cell.Data.Type == itemBase.ItemData.Type)
                    {
                        if (!cell.IsFull)
                        {
                            cell.Add(itemBase);
                            //Debug.Log("Changed amount.");
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Trying to find free cell in inventory and put an ItemBase there.
    /// </summary>
    private bool TryPut(ItemBase itemBase)
    {
        foreach (var cell in Cells)
        {
            if (cell.Data.Type == null) // just check data is null
            {
                cell.Add(itemBase);
                //Debug.Log("Added without changing amount.");
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Removes itemBase from inventory.
    /// </summary>
    //public void Remove(ItemBase itemBase) // Work not guaranteed!
    //{
    //    if (itemsTypes.Contains(itemBase.GetType()))
    //    {
    //        foreach (CellInventory cell in cells)
    //        {
    //            if (cell.ItemType == itemBase.GetType())
    //            {
    //                cell.Subtract();
    //                if (cell.IsEmpty) itemsTypes.Remove(itemBase.GetType());
    //                return;
    //            }
    //        }
    //    }
    //}

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

    public bool DecreaseAmount(int indexOfCell, int amount)
    {
        return Cells[indexOfCell].DecreaseAmount(amount);
    }

    private void CheckInventoryData(InventoryData inventoryData)
    {
        if (inventoryData.Cells.Length <= 0) throw new ArgumentException("Wrong length of Inventory!");
    }
}
