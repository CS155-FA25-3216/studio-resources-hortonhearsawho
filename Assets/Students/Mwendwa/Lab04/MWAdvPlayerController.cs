using UnityEngine;
using UnityEngine.InputSystem;

public class MWAdvPlayerController : MonoBehaviour
{
    MwenMovement movement;
    void Start()
    {
        movement = GetComponent<MwenMovement>();
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y);
        movement.DoMove(direction);
    }
    
    void OnJump(InputValue value)
    {
        if (value.isPressed)
            movement.DoJump(true);
    }
}
