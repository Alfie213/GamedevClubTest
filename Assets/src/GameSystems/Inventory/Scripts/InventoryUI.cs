using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject cellSample;
    [SerializeField] private GameObject emptyCell;

    [Header("InventoryData")]
    [SerializeField] private InventoryData data;
    
    private Inventory inventory;
    private List<GameObject> cellsUi;

    private void Awake()
    {
        inventory = new Inventory(data);
        cellsUi = new List<GameObject>();
        
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //Debug.Log("Inventory enabled");
        InstantiateInventoryUI();
        
        EventBus.InventoryOnClearCell.Subscribe(InstantiateInventoryUI);
    }

    private void OnDisable()
    {
        cellsUi.Clear();
        
        EventBus.InventoryOnClearCell.Unsubscribe(InstantiateInventoryUI);
        EventBus.InventoryUiOnDisable.Publish();
    }

    public Vector3 GetCellUiPosition(int index)
    {
        return cellsUi[index].GetComponent<RectTransform>().position;
    }
    
    private void InstantiateInventoryUI()
    {
        ClearInventoryUI();

        for (int i = 0; i < inventory.Cells.Length; i++)
        {
            if (!inventory.Cells[i].IsEmpty)
            {
                int indexOfCell = i;
                
                GameObject cellUI = Instantiate(cellSample, transform);
                cellsUi.Add(cellUI);
                cellUI.GetComponentInChildren<Image>().sprite = inventory.Cells[i].Data.ItemData.Sprite;
                cellUI.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(inventory.Cells[i].Data.CurrentAmount);
                cellUI.GetComponent<Button>().onClick.AddListener(() => EventBus.InventoryCellClick.Publish(indexOfCell));

                if (inventory.Cells[i].Data.CurrentAmount == 1)
                    cellUI.GetComponentInChildren<TextMeshProUGUI>().gameObject.SetActive(false);
            }
            else
            {
                GameObject emptyCellUI = Instantiate(emptyCell, transform);
                cellsUi.Add(emptyCellUI);
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
        
        cellsUi.Clear();
    }
}
