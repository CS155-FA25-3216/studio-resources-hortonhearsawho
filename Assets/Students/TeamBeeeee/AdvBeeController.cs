//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class AdvBeeController : MonoBehaviour
{
    private Transform playerTransform;

    private float heightOffset = 1f;
    private float orbitRadius = 2f;
    private float orbitSpeed = 2f;
    private float angle = 0f; //current angle of orbit

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player")?.transform;
        if (playerTransform == null)
        {
            Debug.LogError("Player not found. Check Tag.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) return;

        //increment angle based on speed and deltaTime
        angle += orbitSpeed * Time.deltaTime;

        // calc offsets using sine and cosine for circle motion
        float xOffset = Mathf.Cos(angle) * orbitRadius;
        float zOffset = Mathf.Sin(angle) * orbitRadius;

        //set bee position
        Vector3 newPosition = playerTransform.position + new Vector3(xOffset, heightOffset, zOffset);
        transform.position = newPosition;


    }
}