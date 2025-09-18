//using System.Numerics;
using UnityEngine;

public class AdvAIController : MonoBehaviour
{
    Movement movement;
    Transform playerTransform;

    Vector3 origin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<Movement>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if the player is close move towards
        Vector3 toPlayer = playerTransform.position - gameObject.transform.position;
        float distance = toPlayer.sqrMagnitude;

        if (distance < 10f)
        {
            toPlayer.y = 0f;
            movement.Facing = toPlayer.normalized;
            movement.DoMove(toPlayer.normalized);
        }
    
        else
        {
            Vector3 toOrigin = origin - transform.position;
            toOrigin.y = 0f;
            movement.Facing = toOrigin.normalized;
            movement.DoMove(toOrigin.normalized);

        } 
    }
}
