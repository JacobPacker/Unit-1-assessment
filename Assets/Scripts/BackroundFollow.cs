using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackroundFollow : MonoBehaviour
{
    Transform Transform;
    public Transform Player;

    void Start()
    {
        Transform = transform;
    }

    void Update()
    {

        Transform.position = new Vector3(Player.position.x, Transform.position.y, Transform.position.z);
    }
}
