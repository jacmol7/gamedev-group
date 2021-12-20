using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float slideSpeed;

    public AudioClip footStepSound;
    public AudioClip landSound;
    public AudioClip slideSound;
    
    private bool isGrounded;
    private bool isOnWall;
    // The angle of the last wall we touched.
    // This will be 1 or -1, once we touch the floor again then
    // it will be reset to 0
    private float lastTouchingWallDirection; 
    // Reference to the last wall that we touched
    private GameObject lastWall;

    // Cache references to the players components
    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("movementSounds");
    }

    void Update()
    {
        // Need to maintain Y velocity for gravity but always reset the 
        // X velocity to make the controls not feel "floaty"
        float xVelocity = 0f;
        float yVelocity = rb.velocity.y;

        // We should stick to the wall so ignore lateral movement
        if (!isOnWall)
        {
            if (Input.GetKey(KeyCode.A))
            {
                xVelocity -= moveSpeed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                xVelocity += moveSpeed;
            }
        }

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) & isGrounded)
        {
            isGrounded = false;
            
            yVelocity += jumpForce;
        }
        else if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) & isOnWall)
        {
            isOnWall = false;
            yVelocity = jumpForce;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            isOnWall = false;
        }

        if (isOnWall & yVelocity < 0 & yVelocity < -slideSpeed)
        {
            yVelocity = -slideSpeed;
        }

        rb.velocity = new Vector2(xVelocity, yVelocity);

        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isOnWall", isOnWall);

        if (xVelocity < 0)
        {
            animator.SetInteger("movementDirection", -1);
        }
        else if (xVelocity > 0)
        {
            animator.SetInteger("movementDirection", 1);
        }
        else
        {
            animator.SetInteger("movementDirection", 0);
        }

        if (isOnWall)
        {
            animator.SetFloat("wallDirection", lastTouchingWallDirection);
        }
        else
        {
            animator.SetFloat("wallDirection", 0f);
        }
    }

    // Movement sounds that need to keep repeating are handled here.
    // This is so we can sleep for the right ammount of time to avoid overlapping sounds
    // or cutting of one sound to quickly
    private IEnumerator movementSounds()
    {
        while (true)
        {
            if (isGrounded && rb.velocity.x != 0f)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = footStepSound;
                    audioSource.Play();
                    yield return new WaitForSeconds(0.5f);
                }
            }

            while (isOnWall)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.clip = slideSound;
                    audioSource.Play();
                    yield return new WaitForSeconds(slideSound.length);
                    yield return null;
                }
            }
            yield return null;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Terrain")
        {
            ContactPoint2D[] points = new ContactPoint2D[col.contactCount];
            col.GetContacts(points);
            for (int i = 0; i < points.Length; i++)
            {
                // Touched the top of a piece of terrain
                if (points[i].normal.y == 1f)
                {
                    if (!isGrounded)
                    {
                        audioSource.clip = landSound;
                        audioSource.Play();
                    }
                    isGrounded = true;
                    isOnWall = false;
                    lastTouchingWallDirection = 0f;
                }
                // Touched the side of a piece of terrain
                if (points[i].normal.x != 0f && !isGrounded)
                {
                    // You must jump from wall to wall so this prevents simply
                    // leaving the wall for a second to reset the ability to wall jump
                    if (points[i].normal.x != lastTouchingWallDirection)
                    {
                        isOnWall = true;
                        lastTouchingWallDirection = points[i].normal.x;
                        lastWall = col.gameObject;
                    }
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        // Handle the case where we have slid of the end of a wall
        // without jumping off it
        if (col.gameObject == lastWall)
        {
            isOnWall = false;

            
            if (audioSource.clip && audioSource.isPlaying)
            {
                if (audioSource.clip.name == slideSound.name && !isOnWall)
                {
                    audioSource.Stop();
                }
            }
        }
    }
}
