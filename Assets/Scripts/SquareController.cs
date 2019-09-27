using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 20;
    public float jumpForce = 500;
    public LevelController levelC;
    public float distanceToGround;
    public bool normalGravity = true;
    public AudioClip[] jumpSounds;
    public AudioClip fallThud;
    public ParticleSystem entranceEffect;
    public ParticleSystem dustEffect;
    public bool hasSecondJump = false;

    private void Awake() 
    {
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        Instantiate(entranceEffect, transform.position, Quaternion.identity);

        levelC = GetComponent<LevelController>();
        rb = GetComponent<Rigidbody2D>();

        distanceToGround = GetComponent<Collider2D>().bounds.extents.y;
    }

    void Update()
    {
        GetInputs();


    }

    private void GetInputs()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) && normalGravity) || (Input.GetKey(KeyCode.RightArrow) && !normalGravity))
            rb.AddForce(new Vector2(-speed, 0));
        
        if ((Input.GetKey(KeyCode.RightArrow) && normalGravity) || (Input.GetKey(KeyCode.LeftArrow) && !normalGravity))
            rb.AddForce(new Vector2(speed, 0));

        if (Input.GetKeyDown(KeyCode.R))
            levelC.RestartLevel();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((normalGravity && IsGrounded()) || (!normalGravity && IsOnCeiling()))
                Jump();
            else if (hasSecondJump)
            {
                Jump();
                hasSecondJump = false;
            }
            
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && ((normalGravity && IsGrounded()) || (!normalGravity && IsOnCeiling()))) 
        {
            HitGround();
        }
    }

    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position + Vector3.down * 1.05f * distanceToGround, Vector3.down, distanceToGround * .05f);
    }

    bool IsOnCeiling()
    {
        return Physics2D.Raycast(transform.position + Vector3.up * 1.05f * distanceToGround, Vector3.up, distanceToGround * .05f);
    }

    void Jump()
    {
        if (normalGravity)
            rb.AddForce(new Vector2(0, jumpForce));
        else 
            rb.AddForce(new Vector2(0, -jumpForce));
        levelC.IncrementJumpCounter();
    
        int indexToPlay = Random.Range(0, jumpSounds.Length);
        AudioClip jumpSound = jumpSounds[indexToPlay];

        AudioSource.PlayClipAtPoint(jumpSound, transform.position);
    }

    void HitGround()
    {
        ParticleSystem dust = Instantiate(dustEffect, transform.position + Vector3.down * distanceToGround, Quaternion.Euler(-90, 0, 0));
        //dust.transform.parent = transform;
        AudioSource.PlayClipAtPoint(fallThud, transform.position);
    }
}
