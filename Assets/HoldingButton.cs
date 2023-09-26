using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class HoldingButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UnityEvent onHolding;

    private bool holdingButton;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        holdingButton = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        holdingButton = false;
    }

    private void Update()
    {
        if (holdingButton)
            onHolding.Invoke();
    }
}
