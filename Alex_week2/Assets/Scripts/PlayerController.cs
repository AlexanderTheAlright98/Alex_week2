using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 7500;
    public float turnSpeed = 25;
    public int collisions = 0;
    public string playerIndex;
    public AudioClip poleSFX;
    public AudioClip carhitSFX;

    Rigidbody rb;
    private float vertical, horizontal;
    private AudioSource sfxAudio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sfxAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical" + playerIndex);
        horizontal = Input.GetAxis("Horizontal" + playerIndex);

        //With the way the game works, it's quite easy to get permanently stuck if you hit something. Having an instant main menu button is also udeful for if you get bored during the Joyridin' game mode
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
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
            sfxAudio.PlayOneShot(poleSFX);
        }

        if  (collision.gameObject.tag == "StationaryVehicle")
        {
            sfxAudio.PlayOneShot(carhitSFX);
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
