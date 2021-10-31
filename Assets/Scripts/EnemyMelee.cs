using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyMelee : MonoBehaviour
{
    public GameObject player;
    public float enemyspeed;
    private Animator anim;
    private Rigidbody2D rb;
    private bool movingRight = true;
    public Transform groundDetection;
    private bool Stop = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if (player.transform.position.x < -transform.position.x)
        //{
        // Helper.FlipSprite(gameObject, Left);
        //}

        //if (player.transform.position.x > transform.position.x)
        //{
        //Helper.FlipSprite(gameObject, Right);
        //}
        //Throw spear when player is less than 20m away
        float ex = transform.position.x;

        float px = player.transform.position.x;

        float dist = ex - px;

        if (dist < 1f && dist > -1f)
        {

            
            if (player.transform.position.x < -transform.position.x)
            {
                anim.SetBool("Walk", true);
                Helper.FlipSprite(gameObject, Right);
                enemyspeed = 0.3f;
                
            }
            if (player.transform.position.x > transform.position.x)
            {
                anim.SetBool("Walk", true);
                Helper.FlipSprite(gameObject, Left);
                enemyspeed = -0.3f;
                
            }
        }

        else
        {
            anim.SetBool("Walk", true);
            
        }
        if (dist < 0.2f && dist > -0.2f)
        {
            Stop = true;
            anim.SetBool("Attack", true);
        }

        else
        {
            anim.SetBool("Attack", false);
            enemyspeed = 0.3f;
            Stop = false;
        }
        if (Stop == true)
        {
            enemyspeed = 0;
        }

        Helper.FacePlayer(player, gameObject);


        //enemy detects end of platforms
        transform.Translate(Vector2.right * enemyspeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 0.15f);
        if (groundInfo.collider == false)
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    //void OnCollisionEnter2D(Collision2D col)
    //{
    //  print("tag=" + col.gameObject.tag);
    //
    //if (col.gameObject.tag == "Bullet")
    //{
    //  print("I've been hit by a bullet!");
    //
    //}
    //}
    




}
