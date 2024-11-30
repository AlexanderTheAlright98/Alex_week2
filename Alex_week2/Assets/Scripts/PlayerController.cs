using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7500;
    public float turnSpeed = 25;
    public int collisions = 0;
    public string playerIndex;
    public AudioClip poleSFX;

    Rigidbody rb;
    private float vertical, horizontal;
    private AudioSource poleAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        poleAudio = GetComponent<AudioSource>();
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

        transform.Rotate(0, turnSpeed * horizontal * Time.deltaTime, 0);
        // I know that rb.AddTorque is the "proper" way to do this, but the above method results in sharper, more arcade-y handling, which I think feels more fun to play
        // The cars can rotate when stationary, but I think it helps the game feel more arcade-y.
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            collisions++;
        }

        if (collision.gameObject.tag == "Pole")
        {
            poleAudio.PlayOneShot(poleSFX);
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
