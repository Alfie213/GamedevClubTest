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
            if (joystick.JoystickVec.x < 0) // Moving left
            {
                transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
                EventBus.PlayerMovesLeft.Publish();
            }
            else if (joystick.JoystickVec.x > 0) // Moving right
            {
                transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
                EventBus.PlayerMovesRight.Publish();
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}