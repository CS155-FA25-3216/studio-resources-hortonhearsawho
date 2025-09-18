using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class AdvPlayerController : MonoBehaviour
{
    Movement movement;

    void Awake()
    {
        gameObject.tag = "Player";
    }

    void Start()
    {
        movement = GetComponent<Movement>();
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

