using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float moveSpeed = 2500;
    public float reverseSpeed = 20;
    public float leftsidemoveSpeed = -5;
    public float rightsidemoveSpeed = 5;
    public int collisions = 0;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (collisions > 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
                //rb.AddForce(Vector3.forward * moveSpeed);
                rb.AddForce(this.transform.forward * moveSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                //transform.Translate(Vector3.back * Time.deltaTime * 0.5f * reverseSpeed);
                rb.AddForce(-this.transform.forward * moveSpeed);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * leftsidemoveSpeed);
            transform.Rotate(0, -0.5f, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(rightsidemoveSpeed * Time.deltaTime, 0, 0);
            //rb.AddForce(Vector3.right * rightsidemoveSpeed);
            transform.Rotate(0, 0.5f, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            collisions++;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            collisions--;
        }
    }
}
