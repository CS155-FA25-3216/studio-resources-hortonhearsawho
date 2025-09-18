using UnityEngine;

public class AIbehavior : MonoBehaviour
{
    CharacterMovement movement;
    Transform playerTransform;
    Vector3 origin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<CharacterMovement>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is close, move towards
        Vector3 toPlayer = playerTransform.position - transform.position;
        float distance = toPlayer.magnitude;

        if (distance < 5f)
        {
            toPlayer.y = 0f;
            movement.DoMove(toPlayer.normalized);
        }
        else
        {
            Vector3 toOrigin = origin - transform.position;
            toOrigin.y = 0f;
            movement.DoMove(toOrigin);
        }
    }
}
