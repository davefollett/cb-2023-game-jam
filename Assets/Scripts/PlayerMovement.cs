using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 originalPos;
    Vector2 lastPos;
    private bool moving = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlayerCollision>().isAlive())
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector2 movementDirection = new Vector2(horizontal, vertical);
            movementDirection.Normalize();

            Vector2 position = transform.position;
            position.x = position.x + 3.0f * horizontal * Time.deltaTime;
            position.y = position.y + 3.0f * vertical * Time.deltaTime;
            transform.position = position;

            if (movementDirection != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
            }

            if (position == lastPos)
            {
                moving = false;
            } else
            {
                moving = true;
            }

            lastPos = position;
        } else
        {
            moving = false;
        }
    }

    public void restart()
    {
        transform.position = originalPos;
    }

    public bool isMoving()
    {
        return moving;
    }
}
