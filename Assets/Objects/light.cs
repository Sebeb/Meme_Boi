using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour {
    Rigidbody rigidBody;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start () {
        rigidBody.velocity = new Vector3(0, 0, -game.controller.speed);
	}

}
