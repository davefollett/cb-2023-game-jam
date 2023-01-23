using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerMovement : MonoBehaviour
{
    public GameObject player;
    private bool moving = false;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2.8f * Time.deltaTime);
            Vector2 movementDirection = player.transform.position - transform.position;
            movementDirection.Normalize();

            if (movementDirection != Vector2.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movementDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
            }
        }
    }

    //public void startMoving()
    //{
    //    moving = true;
    //}

    public void stopMoving()
    {
        moving = false;
    }

    public void restart()
    {
        transform.position = originalPos;
        moving = true;
    }
}
