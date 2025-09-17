using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float acceleration = 20f;
    [SerializeField] float maxSpeed = 10f;
    [SerializeField] float jumpStrength = 20f;
    public Vector3 Facing { get; set; }
    public float Acceleration { get { return acceleration; } set { acceleration = value; } }
    public float MaxSpeed { get { return maxSpeed; } set { maxSpeed = value; } }
    Vector3 movementDelta;
    bool tryJump;
    bool isGrounded;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void DoMove(Vector3 direction)
    {
        movementDelta = direction * acceleration;
    }

    public void DoJump(bool value)
    {
        tryJump = value;
    }

    void Update()
    {
        if (tryJump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            isGrounded = false;
        }
        tryJump = false; // Clear the jump so it doesn't auto trigger on landing
    }

    void FixedUpdate()
    {
        if (movementDelta != Vector3.zero)
        {
            rb.AddForce(movementDelta, ForceMode.Acceleration);
        }
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        if (Facing != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(Facing);
        }
        else if (movementDelta.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(movementDelta.normalized);
        }
    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
