using System.IO;
using UnityEngine;
using UnityEngine.AI;


public class MWAdvAIController : MonoBehaviour
{
    MwenMovement movement;

    Transform playerTransform;

    Vector3 origin;

    bool wallContact = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<MwenMovement>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // // if player is close move towards
        // Vector3 toPlayer = playerTransform.position - transform.position;
        // float distance = toPlayer.magnitude;

        // if (distance < 5f)
        // {
        //     toPlayer.y = 0f;
        //     movement.DoMove(toPlayer.normalized);
        // }
        // else
        // {
        //     Vector3 toOrigin = origin - transform.position;
        //     toOrigin.y = 0f;
        //     movement.DoMove(toOrigin.normalized);
        // }

        // if player is close flee
        Vector3 fromPlayer = playerTransform.position + transform.position;
        float distance = fromPlayer.magnitude;

        if (distance > 5f && !wallContact)
        {
            fromPlayer.y = 0f;
            movement.DoMove(fromPlayer.normalized);
        }
        else
        {
            Vector3 toOrigin = origin - transform.position;
            toOrigin.y = 0f;
            float distOrigin = toOrigin.magnitude;
            if (distOrigin > 1.5f)
            {
                movement.DoMove(toOrigin.normalized);
            }
            else
            {
                wallContact = false;
                movement.DoMove(Vector3.zero);
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.CompareTo("nmeWall") == 0)
        {
            wallContact = true;
            movement.DoJump(true);
            movement.DoMove(Vector3.zero);
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag.CompareTo("nmeWall") == 0)
        {
            wallContact = false;
        }
    }*/
}
