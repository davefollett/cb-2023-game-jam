using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "seeker")
        {
            // Destroy(collision.gameObject);
            // Debug.Log("hit");
            alive = false;
        }
        
    }

    public bool isAlive()
    {
        return alive;
    }

    public void restart()
    {
        alive = true;
    }
}
