using UnityEngine;

public class ItemDeleteWindow : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;
    
    private void OnEnable()
    {
        EventBus.InventoryCellClick.Subscribe(Handle_InventoryCellClick);
    }

    private void OnDisable()
    {
        EventBus.InventoryCellClick.Unsubscribe(Handle_InventoryCellClick);
    }

    private void Handle_InventoryCellClick(int indexOfCell)
    {
        transform.position = inventoryUI.GetCellUiPosition(indexOfCell);
        // Тут надо узнать, где находится нужная ячейка и переместить окно удаления на ее место.
        // При нажатии на кнопку надо обратиться к инвентарю и удалить нужный предмет.
    }
}
