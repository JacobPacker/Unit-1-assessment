using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class EnemyShoot : MonoBehaviour
{
    public GameObject player;
    public float enemyspeed;
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject projectilePrefab;
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

        if (dist < 2f && dist > -2f)
        {


            anim.SetBool("Attack", true);
        }
        else
        {
            anim.SetBool("Attack", false);
            enemyspeed = 0.3f;

        }


    
        if (dist < -0.01f)
        {
            Helper.FlipSprite(gameObject, Right);
        }
        else
        {
            Helper.FlipSprite(gameObject, Left);
        }
        

        Helper.FacePlayer(player, gameObject);


        
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player projectile")
        {
            Destroy(gameObject);
        }
    }
    void shoot()
    {
        float ex = transform.position.x;

        float px = player.transform.position.x;

        float dist = ex - px;

        
        if (dist < 2 && dist > 0)
        {
            // Launch projectile from player
            Helper.MakeBullet(projectilePrefab, transform.position.x - 0.12f, transform.position.y + 0.2f, -5.0f, 0f);

        }
        if (dist > -2 && dist < 0)
        {
            // Launch projectile from player
            Helper.MakeBullet(projectilePrefab, transform.position.x + 0.12f, transform.position.y + 0.2f, 5.0f, 0f);

        }
    }



}
