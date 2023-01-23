using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
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
        }
    }

    public void restart()
    {
        transform.position = originalPos;
    }
}
