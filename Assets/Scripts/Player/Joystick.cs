using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public Vector2 JoystickVec { get; private set; }
    
    [SerializeField] private GameObject circle;
    [SerializeField] private GameObject ring;

    private const int CircleAreaLimit = 4;
    
    private Vector2 ringOriginalPos;
    private Vector2 circleOriginalPos;
    private Vector2 joystickTouchPos;
    
    private float joystickRadius;

    private void Start()
    {
        ringOriginalPos = ring.GetComponent<RectTransform>().localPosition;
        circleOriginalPos = ring.GetComponent<RectTransform>().localPosition;
        joystickRadius = ring.GetComponent<RectTransform>().sizeDelta.y / CircleAreaLimit;
    }

    public void PointerDown()
    {
        circle.transform.position = Input.mousePosition;
        ring.transform.position = Input.mousePosition;
        joystickTouchPos = Input.mousePosition;
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector2 dragPos = pointerEventData.position;
        JoystickVec = (dragPos - joystickTouchPos).normalized;

        float joystickDist = Vector2.Distance(dragPos, joystickTouchPos);

        if(joystickDist < joystickRadius)
        {
            circle.transform.position = joystickTouchPos + JoystickVec * joystickDist;
        }

        else
        {
            circle.transform.position = joystickTouchPos + JoystickVec * joystickRadius;
        }
    }

    public void PointerUp()
    {
        JoystickVec = Vector2.zero;
        ring.GetComponent<RectTransform>().localPosition = ringOriginalPos;
        circle.GetComponent<RectTransform>().localPosition = circleOriginalPos;
    }
}