using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerMovement : MonoBehaviour
{
    public GameObject player;
    private bool moving = false;
    Vector2 originalPos;
    public AudioSource warp;
    public AudioSource flying;
    public AudioSource bump;

    // Start is called before the first frame update
    void Start()
    {
        //originalPos = transform.position;
        warpSeeker();
        //stopMoving();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!player.GetComponent<PlayerMovement>().isMoving())
        //{
        //    stopMoving();
        //} else
        //{
        //    startMoving();
        //}

        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, -1 * 1.8f * Time.deltaTime);
            Vector2 movementDirection = (player.transform.position - transform.position) * -1;
            movementDirection.Normalize();

            if (movementDirection != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "top-wall"
            || collision.gameObject.tag == "bottom-wall"
            || collision.gameObject.tag == "left-wall"
            || collision.gameObject.tag == "right-wall")
        {
            //Debug.Log("hit wall");
            //float spawnY = Random.Range
            //    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            //float spawnX = Random.Range
            //    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            //Vector2 spawnPosition = new Vector2(spawnX, spawnY);
            //transform.position = spawnPosition;
            warpSeeker();
            warp.Play();
        }

        if (collision.gameObject.tag == "crate")
        {
            bump.Play();
        }

        if (collision.gameObject.tag == "player")
        {
            stopMoving();
        }
    }
    public void stopMoving()
    {
        moving = false;
        flying.Stop();
    }

    public void startMoving()
    {
        moving = true;
        //flying.Play();
    }

    public void restart()
    {
        warpSeeker();
        //transform.position = originalPos;
        moving = true;
        flying.Play();
    }

    public void warpSeeker()
    {
        float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        transform.position = spawnPosition;
    }
}
