using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class zMovement : MonoBehaviour {
    Rigidbody rigidBody;
    public float speed;
    public bool relativeSpeed;
    float gameSpeed;
    AudioSource audio;
    public bool moving = true;

	void Awake () {
        rigidBody = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
	}

    void Start()
    {
        if (relativeSpeed)
            gameSpeed = game.controller.speed;
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -(speed + gameSpeed));
    }

    void FixedUpdate () {
        if (moving)
        {
            if (relativeSpeed)
                gameSpeed = game.controller.speed;
            if (rigidBody.velocity.z > -(speed + gameSpeed))
                rigidBody.AddForce(new Vector3(0, 0, -80));
            else
                rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, -(speed+gameSpeed));

            if (transform.position.z < -game.controller.spawnZ || transform.position.x < (-game.controller.upperBound - 3))
                Destroy(gameObject);
            if (audio != null && transform.position.z < 0)
                audio.maxDistance = 30;
        }
	}
}
