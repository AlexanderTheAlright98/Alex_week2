using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingVehicle : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed = 200;
    public bool hascollidedwithVehicle = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (!hascollidedwithVehicle)
        {
            rb.AddForce(this.transform.forward * 0.75f * moveSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "StationaryVehicle")
        {
            rb.linearVelocity = Vector3.zero;
            hascollidedwithVehicle = true;
        }

        if (collision.gameObject.tag == "PlayerCar")
        {
            rb.linearVelocity = Vector3.zero;
            hascollidedwithVehicle = true;
        }
    }
}

