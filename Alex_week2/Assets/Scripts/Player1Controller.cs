using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float moveSpeed = 20;
    public float leftsidemoveSpeed = -5;
    public float rightsidemoveSpeed = 5;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(leftsidemoveSpeed *  Time.deltaTime, 0, 0);
            transform.Rotate(0, -0.5f, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(rightsidemoveSpeed * Time.deltaTime, 0, 0);
            transform.Rotate(0, 0.5f, 0);
        }
    }
}
