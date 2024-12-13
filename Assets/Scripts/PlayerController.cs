using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float jumpspeed;
    float xspeed;
    float xdirection;
    float xvector;
    float yspeed;
    float ydirection;
    float yvector;
    Rigidbody2D rb;
    public bool overworld;
    private bool canJump;
    private bool isGrounded;
   
    public Transform groundCheck; // A point at the bottom of the player to check ground
    public LayerMask groundLayer; // Layer to detect as "ground"
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Initialize Rigidbody2D

        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        xspeed = 5;
        yspeed = 5;
        jumpspeed = 10f;
        if (overworld)
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            canJump = false;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            canJump = true;
        }
    }

    private void Update()
    {
        xdirection = Input.GetAxis("Horizontal");
        xvector = xspeed * xdirection * Time.deltaTime;
        transform.Translate(xvector, 0, 0);

        ydirection = Input.GetAxis("Vertical");
        yvector = yspeed * ydirection * Time.deltaTime;
        transform.Translate(0, yvector, 0);
        
        if (canJump && isGrounded && Input.GetButtonDown("Jump"))
        {
            Debug.Log("jump pressed");
            Jump();
        }
        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        Debug.Log("is grounded" + isGrounded);
    }
    
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            print("You hit a wall.");
        }
    }

    private void Jump()    
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpspeed);          
        }
        
    }
}