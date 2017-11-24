using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    Rigidbody rigidBody;
    AudioSource audioSource;
	public int life;
	public int maxHealth;
	[HideInInspector]
	public int health;


    public bool dead;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
		health = maxHealth;

    }

    public void OnHit(){
		if (health == 0)
        	Die();
    }

    void Die()
    {
        if (!dead)
        {
            dead = true;
            rigidBody.constraints = RigidbodyConstraints.None;
			if (GetComponent<zMovement>()!=null)
				GetComponent<zMovement>().moving = false;
            gameObject.layer = 21;
            rigidBody.useGravity = true;
			DisableBounce();
            rigidBody.AddForce(new Vector3(0, 40, 10));
        }
    }

	void DisableBounce(){
		if (GetComponent<BoxCollider>()!= null)
			GetComponent<BoxCollider>().material = Resources.Load("Materials/NotBouncy") as PhysicMaterial;
		else if (GetComponent<CapsuleCollider>()!= null)
			GetComponent<CapsuleCollider>().material = Resources.Load("Materials/NotBouncy") as PhysicMaterial;
	}

	#region Drag on ground
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 23 && dead)
        {
            rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y,
                                             Mathf.Clamp(rigidBody.velocity.z-1, -game.controller.speed,20));
        }
    }
	#endregion

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
