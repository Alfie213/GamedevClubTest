using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDeleteButton : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;

    private Image image;
    private TextMeshProUGUI text;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetEnableGraphics(false);
    }

    private void OnEnable()
    {
        EventBus.InventoryCellClick.Subscribe(Handle_InventoryCellClick);
        EventBus.InventoryUiOnDisable.Subscribe(Handle_InventoryUiOnDisable);
    }

    private void OnDisable()
    {
        EventBus.InventoryCellClick.Unsubscribe(Handle_InventoryCellClick);
        EventBus.InventoryUiOnDisable.Unsubscribe(Handle_InventoryUiOnDisable);
    }

    private void SetEnableGraphics(bool state)
    {
        image.enabled = state;
        text.enabled = state;
    }
    
    private void Handle_InventoryCellClick(int indexOfCell)
    {
        transform.position = inventoryUI.GetCellUiPosition(indexOfCell);
        SetEnableGraphics(true);
        // Тут надо узнать, где находится нужная ячейка и переместить окно удаления на ее место.
        // При нажатии на кнопку надо обратиться к инвентарю и удалить нужный предмет.
    }

    private void Handle_InventoryUiOnDisable()
    {
        SetEnableGraphics(false);
    }
}
