using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    Rigidbody rigidBody;
    AudioSource audioSource;
    BoxCollider collider;

    public bool dead;
    float deadX;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collider = GetComponent<BoxCollider>();

    }

    public void OnHit(){
        Die();
    }

    void Die()
    {
        if (!dead)
        {
            dead = true;
            deadX = transform.position.x;
            gameObject.layer = 21;
            rigidBody.useGravity = true;
            rigidBody.constraints = RigidbodyConstraints.None;
            rigidBody.AddForce(new Vector3(0, 100, 150));
        }
    }

    void Update()
    {
        if (dead)
        {
            if (transform.position.x > -game.controller.upperBound)
            {
                audioSource.pitch = (transform.position.x+game.controller.upperBound)/(deadX+game.controller.upperBound) ;
            }
            else
                audioSource.Stop();
        }
    }



}
