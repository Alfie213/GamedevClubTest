using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject cellSample;
    [SerializeField] private GameObject emptyCell;

    private Inventory inventory;
    
    [SerializeField] private InventoryData data;

    private void Awake()
    {
        inventory = new Inventory(data);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //Debug.Log("Inventory enabled");
        InstantiateInventoryUI();
    }

    private void InstantiateInventoryUI()
    {
        ClearInventoryUI();
        
        foreach (CellInventory cell in inventory.Cells)
        {
            if (!cell.IsEmpty)
            {
                cellSample.GetComponentInChildren<Image>().sprite = cell.Data.ItemData.Sprite;
                cellSample.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(cell.Data.CurrentAmount);
                GameObject temp = Instantiate(cellSample, this.transform);
                // switch (cell.Data.Type)
                // {
                //     case ItemData.ItemType.IntelligenceBook:
                //         temp.AddComponent<IntelligenceBook>();
                //         break;
                //     case ItemData.ItemType.StrenghtBook:
                //         temp.AddComponent<StrenghtBook>();
                //         break;
                //     case ItemData.ItemType.Ingredient:
                //         temp.AddComponent<Ingredient>();
                //         break;
                //     case ItemData.ItemType.HealthPotion:
                //         temp.AddComponent<HealthPotion>();
                //         break;
                //     case ItemData.ItemType.ManaPotion:
                //         temp.AddComponent<ManaPotion>();
                //         break;
                //     case ItemData.ItemType.Boomerang:
                //         temp.AddComponent<Boomerang>();
                //         break;
                //     case ItemData.ItemType.BowArrow:
                //         temp.AddComponent<BowArrow>();
                //         break;
                //     case ItemData.ItemType.Cyborg:
                //         temp.AddComponent<Cyborg>();
                //         break;
                //     case ItemData.ItemType.Hat:
                //         temp.AddComponent<Hat>();
                //         break;
                //     case ItemData.ItemType.Kusarigama:
                //         temp.AddComponent<Kusarigama>();
                //         break;
                //     case ItemData.ItemType.Orrery:
                //         temp.AddComponent<Orrery>();
                //         break;
                //     case ItemData.ItemType.Sablya:
                //         temp.AddComponent<Sablya>();
                //         break;
                //     case ItemData.ItemType.Shuriken:
                //         temp.AddComponent<Shuriken>();
                //         break;
                //     case ItemData.ItemType.Sword:
                //         temp.AddComponent<Sword>();
                //         break;
                //     default:
                //         throw new ArgumentException("Unknown type of item.");
                // }
                // temp.GetComponent<Item>().SetItemData(cell.Data.ItemData);
            }
            else
            {
                Instantiate(emptyCell, transform);
            }
        }
    }
    
    /// <summary>
    /// Clears all inventory UI.
    /// </summary>
    private void ClearInventoryUI()
    {
        Transform[] children = GetComponentsInChildren<Transform>();

        // Starting from 1 to avoid self deleting.
        for (int i = 1; i < children.Length; i++)
        {
            Destroy(children[i].gameObject);
        }
    }
}
