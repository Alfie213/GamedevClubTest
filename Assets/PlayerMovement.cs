using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float speed;
    
    private Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if(joystick.JoystickVec.y != 0)
        {
            rb.velocity = new Vector2(joystick.JoystickVec.x * speed, joystick.JoystickVec.y * speed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}