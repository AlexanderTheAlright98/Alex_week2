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
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            hascollidedwithVehicle = true;
        }

        if (collision.gameObject.tag == "PlayerCar")
        {
            GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            hascollidedwithVehicle = true;

            //Commenting this out because it makes the moving vehicles fall through the ground. Not sure as to the workaround yet.
            //private void OnTriggerEnter(Collider other)
            //{
            //    if (other.gameObject.tag == "StationaryVehicle")
            //   {
            //        GetComponent<Rigidbody>().linearVelocity= Vector3.zero;
            //        hascollidedwithVehicle = true;
            //   }
            //
            //    if (other.gameObject.tag == "PlayerCar")
            //    {
            //        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            //        hascollidedwithVehicle = true;
            //    }
        }
    }
}

