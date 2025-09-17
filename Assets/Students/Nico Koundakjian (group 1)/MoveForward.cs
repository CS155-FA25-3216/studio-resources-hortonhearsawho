using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //[SerializeField] GameObject ball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.back);
    }
}
