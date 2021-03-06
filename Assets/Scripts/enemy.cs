using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
    Rigidbody rigidBody;
    AudioSource audioSource;
    audioPitchSlowmo audioPitch;

    [HideInInspector]
	public int maxHealth;
	public int health;

    public bool dead;
    public string name;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        audioPitch = GetComponent<audioPitchSlowmo>();
        maxHealth= health;

    }

    public bool OnHit(int damage){
        if (!dead)
        {
            rigidBody.AddForce(0,0,300);
            if (game.controller.targetedEnemy != this)
            {
                game.controller.targetedEnemy = this;
                game.controller.displayedEnemyHealth = health;
                game.controller.maxEnemyHealth = maxHealth;
            }
            health = Mathf.Clamp(health - damage, 0, maxHealth);
            game.controller.enemyHealth = health;

            if (health == 0)
            {
                Die();
                return true;
            }
        }
        if (GetComponent<sfxManager>() != null)
            GetComponent<sfxManager>().PlaySound();
        return false;
    }

    void Die()
    {
        if (!dead)
        {
            if (game.controller.targetedEnemy == this)
                game.controller.targetedEnemy = null;
            dead = true;
            game.controller.score += 10;
            rigidBody.constraints = RigidbodyConstraints.None;
			if (GetComponent<zMovement>()!=null)
				GetComponent<zMovement>().moving = false;
            gameObject.layer = 21;
            rigidBody.useGravity = true;
			DisableBounce();
            rigidBody.AddForce(new Vector3(0, 40, 10));
            GetComponent<SpriteRenderer>().color = new Color(Random.Range(0,2), Random.Range(0, 2), Random.Range(0, 2), 0.6f);
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
            if (audioPitch.normalPitch > 0.1f)
            {
                audioPitch.normalPitch *= 1.04f;
            }
			if (audioSource.volume > 0.3f)
			{
				audioSource.volume /= 1.001f;
			}
        }
    }



}
