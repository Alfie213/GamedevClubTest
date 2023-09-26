using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDeleteButton : MonoBehaviour
{
    [SerializeField] private InventoryUI inventoryUI;

    private Image image;
    private TextMeshProUGUI text;

    private int currentCellIndex;

    private void Awake()
    {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => EventBus.ItemDeleteButtonOnClick.Publish(currentCellIndex));
        GetComponent<Button>().onClick.AddListener(() => SetEnableGraphics(false));
        
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
        currentCellIndex = indexOfCell;
        transform.position = inventoryUI.GetCellUiPosition(indexOfCell);
        SetEnableGraphics(true);
    }

    private void Handle_InventoryUiOnDisable()
    {
        SetEnableGraphics(false);
    }
}
