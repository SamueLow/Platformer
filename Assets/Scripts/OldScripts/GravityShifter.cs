using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityShifter : MonoBehaviour
{
    Rigidbody2D rb;

    bool gravityIsDown = true;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            gravityIsDown = !gravityIsDown;

        if (gravityIsDown)
            rb.gravityScale = 3;

        else
            rb.gravityScale = -3;
    }
}
