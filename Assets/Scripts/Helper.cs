using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;
public class Helper : MonoBehaviour
{
    //flips sprite
    public static void FlipSprite(GameObject obj, float dir)
    {
        if (dir == Left)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


    }
    //Throw spear when player is less than 20m away
    public static void FacePlayer(GameObject object1, GameObject object2)
    {
        float x1 = object1.transform.position.x;
        float x2 = object2.transform.position.x;
        float dist = x2 - x1;

    }

    public static float GetObjectDir(GameObject obj)
    {
        float ang = obj.transform.eulerAngles.y;
        if (ang == 180)
        {
            return Left;
        }
        else
            return Right;
    }

    public static void MakeBullet(GameObject prefab, float xpos, float ypos, float xvel, float yvel)
    {
        // instantiate the object at xpos,ypos
        GameObject instance = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity);

        // set the velocity of the instantiated object
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(xvel, yvel, 0);

        // set the direction of the instance based on the x velocity
        FlipSprite(instance, xvel < 0 ? Left : Right);
    }
    public static void SetVelocity(GameObject obj, float xvel, float yvel)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(xvel, yvel, 0);
    }

    public static bool DoRayCollisionCheck(GameObject obj)
    {
        float rayLength = 0.015f;
        float x = obj.transform.position.x;
        float y = obj.transform.position.y - 0.015f;

        //cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(x, y, obj.transform.position.z), -Vector2.up, rayLength);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {



            if (hit.collider.tag == "Platforms")
            {
                hitColor = Color.green;
                return true;
            }
            if (hit.collider.tag == "Crates")
            {
                hitColor = Color.yellow;
                return true;
            }
            if (hit.collider.tag == "Water")
            {
                hitColor = Color.blue;
                return true;
            }

        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(obj.transform.position, -Vector2.up * rayLength, hitColor);
        return false;
    }

}
