using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float startTime = 120;
    private float currentTime;
    private bool timerStarted;
    public TMP_Text timerTXT;
    public TMP_Text restartTXT;
    public bool playing;
    public AudioSource _AudioSource1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playing = true;
        currentTime = startTime;
        timerTXT.text = currentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (playing)
        {
            timerStarted = true;
        }

        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            timerTXT.text = "TIME: " + currentTime.ToString("f2");
        }

        if (currentTime <= 0)
        {
            Time.timeScale = 0;
            _AudioSource1.Stop();
            restartTXT.text = "TIME'S UP, YOU TWO! PRESS 'R' TO RESTART OR 'M' TO RETURN TO THE MAIN MENU!";

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("2Player");
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MainMenu");
                Time.timeScale = 1;
            }

        }

    }
}
