using UnityEngine;

public class JohnsonAdvAIController : MonoBehaviour
{
    JohnsonMovement movement;
    Transform playerTransform;
    Vector3 origin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<JohnsonMovement>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is close, move towards them
        Vector3 toPlayer = transform.position - gameObject.transform.position;
        float distance = toPlayer.magnitude;

        if (distance < 10f)
        {
            toPlayer.y = 0;
            movement.DoMove(toPlayer.normalized);
        }
        else
        {
            Vector3 toOrigin = origin - transform.position;
            toOrigin.y = 0;
            movement.DoMove(toOrigin);
        }
    }
}
