using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class PlayerScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;

    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        // jump animation goes here
    }
    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("w") && (Helper.DoRayCollisionCheck(gameObject) == true))
        {
            if (velocity.y < 0.001f)
            {
                velocity.y = 2.5f;    // give the player a velocity of 2 in the y axis

            }
        }

        rb.velocity = velocity;
    }
    void DoMove()
    {

        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;


        // check for moving left
        if (Input.GetKey("a"))
        {
            velocity.x = -2;
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            velocity.x = 2;
        }
        //Walk animation goes here
        Helper.SetVelocity(gameObject, velocity.x, velocity.y);
        // Flips sprite depending on which way they are facing
        if (velocity.x < -0.5)
        {
            Helper.FlipSprite(gameObject, Left);
        }
        if (velocity.x > 0.5f)
        {
            Helper.FlipSprite(gameObject, Right);
        }
    }

}

