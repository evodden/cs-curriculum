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
    private void Start()
    {
        //
        GetComponentInChildren<TopDown_AnimatorController>().enabled = overworld;
        GetComponentInChildren<Platformer_AnimatorController>().enabled = !overworld; //what do you think ! means?
        xspeed = 5;
        yspeed = 5;
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
        
    }
}