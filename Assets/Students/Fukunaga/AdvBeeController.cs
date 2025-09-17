using UnityEngine;

public class AdvBeeController : MonoBehaviour
{
    private Movement movement;

    private Transform playerTransform;

    private Vector3 offsetLeft, offsetRight;

    private bool right = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movement = GetComponent<Movement>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        offsetLeft = new Vector3(-1, 2, 0);
        offsetRight = new Vector3(1, 2, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!right)
        {
            gameObject.transform.position = playerTransform.position + offsetRight;
            right = true;
        }
        else
        {
            gameObject.transform.position = playerTransform.position + offsetLeft;
        }
        
    }
}
