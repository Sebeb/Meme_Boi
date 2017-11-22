using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {
    static bool gameStarted = false;
    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {

        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
            rigidBody.velocity = new Vector3(0, 0, -game.controller.speed);
            
    }

}
