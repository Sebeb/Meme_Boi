using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    Rigidbody rigidBody;
    AudioSource audioSource;
    BoxCollider collider;

    public bool dead;

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
            rigidBody.constraints = RigidbodyConstraints.None;
            GetComponent<zMovement>().moving = false;
            gameObject.layer = 21;
            rigidBody.useGravity = true;
            collider.material = Resources.Load("Materials/NotBouncy") as PhysicMaterial;
            rigidBody.AddForce(new Vector3(0, 40, 0));

        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 23 && dead)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y,
                                             Mathf.Clamp(rigidBody.velocity.z-1, -game.controller.speed,20));
        }
    }

    void Update()
    {
        
        if (dead)
        {
            if (audioSource.pitch > 0.035f)
            {
                audioSource.pitch /= 1.015f;
            }
        }
    }



}
