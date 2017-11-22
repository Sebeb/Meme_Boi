﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class zMovement : MonoBehaviour {
    Rigidbody rigidBody;
    public float speed;
    AudioSource audio;
    public bool moving = true;

	void Awake () {
        rigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moving)
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -(game.controller.speed + speed));

        if (transform.position.z < -game.controller.spawnZ || transform.position.x < (-game.controller.upperBound - 3))
            Destroy(gameObject);
        if (audio != null && transform.position.z < 0)
            audio.maxDistance = 30;
        
	}
}
