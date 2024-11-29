using UnityEngine;
using TMPro;

public class Player1Score : MonoBehaviour
{
    public int p1currentScore = 0;
    public TMP_Text p1scoreTXT;
    private AudioSource contrabandAudio;
    public AudioClip contrabandSFX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        contrabandAudio = GetComponent<AudioSource>();
        p1scoreTXT.text = "P1: " + p1currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        p1scoreTXT.text = "P1: " + p1currentScore.ToString();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Contraband")
        {
            p1currentScore++;
            contrabandAudio.PlayOneShot(contrabandSFX);
        }

    }
}
