using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject seeker;
    public Text timeText;

    private float time = 0.0f;
    private bool running = false;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerCollision>().isAlive() && running)
        {
            time += Time.deltaTime;
            setTimeText();
        }
    }

    public void startRunning()
    {
        time = 0.0f;
        setTimeText();
        running = true;
        seeker.GetComponent<SeekerMovement>().restart();
        player.GetComponent<PlayerCollision>().restart();
        player.GetComponent<PlayerMovement>().restart();
    }

    public void setTimeText()
    {
        timeText.text = string.Format("Time: {0:F1}", time);
    }
}
