using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public float moveSpeed = 7500;
    public float turnSpeed = 7000;
    public int collisions = 0;
    public float cratesAcquired = 0;
    private float vertical, horizontal;
    public string playerIndex;

    Rigidbody rb;
    private AudioSource contrabandAudio;
    public AudioClip contrabandSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contrabandAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical" + playerIndex);
        horizontal = Input.GetAxis("Horizontal" + playerIndex);
    }
    private void FixedUpdate()
    {
        if (collisions > 0)
        {
            rb.AddForce(this.transform.forward * moveSpeed * vertical);
        }

        rb.AddTorque(Vector3.up * turnSpeed * horizontal);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            collisions++;
        }

        if (collision.gameObject.tag == "Contraband")
        {
            cratesAcquired++;
            contrabandAudio.PlayOneShot(contrabandSFX);
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
