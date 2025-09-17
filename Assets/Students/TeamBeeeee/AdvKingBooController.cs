//using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class AdvKingBooController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField, Range(-1f, 1f)] private float behindThreshold = -0.05f;

    [SerializeField] private float hoverHeight = 2f;
    [SerializeField] private float hoverAmplitude = 0.2f;
    [SerializeField] private float hoverFrequency = 1f;
    private Transform playerTransform;
    private Transform ghostTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player")?.transform;
        ghostTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null) return;

        Vector3 toGhost = (ghostTransform.position - playerTransform.position).normalized;

        float dot = Vector3.Dot(playerTransform.forward, toGhost);

        if (dot < behindThreshold)
        {
            Vector3 targetPosition = new Vector3(playerTransform.position.x, ghostTransform.position.y, playerTransform.position.z);
            ghostTransform.position = Vector3.MoveTowards(ghostTransform.position, targetPosition, moveSpeed * Time.deltaTime);

            Vector3 spookyLook = (playerTransform.position - ghostTransform.position).normalized;
            spookyLook.y = 0;
            if (spookyLook != Vector3.zero)
            {
                ghostTransform.rotation = Quaternion.Slerp(ghostTransform.rotation, Quaternion.LookRotation(spookyLook), 2f * Time.deltaTime);
            }        
            

        }

        //ghost bobs up and down
        float hoverOffset = Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude;
        ghostTransform.position = new Vector3(ghostTransform.position.x, hoverHeight + hoverOffset, ghostTransform.position.z);
        
    }
}
