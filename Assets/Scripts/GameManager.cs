using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject seeker;
    public Text timeText;
    public AudioSource bgMusic;

    private float time = 0.0f;
    private bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        bgMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerCollision>().isAlive() && running)
        {
            time += Time.deltaTime;
            setTimeText();
        }

        //if(!running)
        //{
        //    bgMusic.Stop();
        //}
    }

    public void startRunning()
    {
        time = 0.0f;
        setTimeText();
        running = true;
        seeker.GetComponent<SeekerMovement>().restart();
        player.GetComponent<PlayerCollision>().restart();
        player.GetComponent<PlayerMovement>().restart();
        //bgMusic.Play();
    }

    public void setTimeText()
    {
        timeText.text = string.Format("Time: {0:F1}", time);
    }
}
