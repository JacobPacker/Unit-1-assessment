using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    private Animator anim;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float ex = transform.position.x;

        float px = player.transform.position.x;

        float dist = ex - px;

        if (dist < 0.01f && dist > -0.01f)
        {
            anim.SetBool("Fall", true);
        }
    }
}
