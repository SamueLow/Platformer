using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float jumpForce = 600f;
    private float movementSpeed = 20f;
    private float jumpCounter = 0;
    private bool hasJumped = false;
    private bool gravityIsUp = false;
    Rigidbody2D rb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


/*

- remove the ability to fall out of a level, this isn't the same as killing the player when they fall out of your open level.
- only can switch gravity once you hit the ground (much like losing the ability to "jump" when you jump)
- walls aren't ground

- instead of "hasJumped", you increment a jump counter
- when you touch the ground, it gets set to 0
- when you jump it goes up by one
- you can only jump if you haven't jumped twice

- Make a more interesting level, with FAILURE POINTS
- if you fail to jump something, or switch gravity correctly, etc, etc, you end up at the beginning of th elevel (using killzones)
- feel free to do this on pen and paper, and then implement it





NOTES:
- we like flying - what about a level or game design that's about whipping yourself to somewhere
- you have "health", and you lose one health every time you jump.
- super hard platformer where the resource is jumps.

 */

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && !gravityIsUp && !hasJumped)
        {
            rb.AddForce(transform.up * jumpForce);
            hasJumped = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && gravityIsUp && !hasJumped)
        {
            rb.AddForce(transform.up * -jumpForce);
            hasJumped = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravityIsUp = !gravityIsUp;
            rb.gravityScale = -rb.gravityScale;
        }   
       
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // transform.position = new Vector2(transform.position.x + movementSpeed, transform.position.y);
            rb.AddForce(transform.right * movementSpeed);
        } 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(transform.right * -movementSpeed);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)// anytime you touch ANYTHING
    {
        Debug.Log("Stay with me");
        if (other.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
    }
}
