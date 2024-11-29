using UnityEngine;
using TMPro;

public class Player2Score : MonoBehaviour
{
    public int p2currentScore = 0;
    public TMP_Text p2scoreTXT;
    private AudioSource contrabandAudio;
    public AudioClip contrabandSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contrabandAudio = GetComponent<AudioSource>();
        p2scoreTXT.text = "P2: " + p2currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        p2scoreTXT.text = "P2: " + p2currentScore.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Contraband")
        {
            p2currentScore++;
            contrabandAudio.PlayOneShot(contrabandSFX);
        }

    }
}

