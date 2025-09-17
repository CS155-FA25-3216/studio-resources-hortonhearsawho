using UnityEngine;

public class BotAI : MonoBehaviour
{
    private GameObject player;
    private Movement movement;
    private Vector3 origin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<Movement>();
        origin = transform.position;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toPlayer = player.transform.position - transform.position;
        float dist = toPlayer.magnitude;
        if (dist < 5f)
        {
            toPlayer.y = 0;
            movement.DoMove(toPlayer.normalized);
        }
        else
        {
            Vector3 toOrig = origin - transform.position;
            float distToOrig = toOrig.magnitude;
            if (distToOrig > 1.5f)
            {
                toOrig.y = 0;
                movement.DoMove(toOrig.normalized);
            }
            else
            {
                movement.DoMove(Vector3.zero);
            }
        }
        //CheckForJump();
    }

    void CheckForJump()
    {
        movement.DoJump(true);
    }
}
