using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBullet : MonoBehaviour {

	Rigidbody rigidBody;
	public float speed;
	public float reloadTime;
	public int damage;

	void Awake(){
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Start () {
		rigidBody.velocity = new Vector3 (0, 0, speed);
	}
	

    void FixedUpdate()
    {
        if (transform.position.z > game.controller.spawnZ)
            Destroy(gameObject);
		if (rigidBody.velocity.z < speed)
			rigidBody.velocity = new Vector3 (0, 0, speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<enemy>()!=null){
            GameObject otherObejct = collision.gameObject;
			if (!otherObejct.GetComponent<enemy> ().dead) {
				otherObejct.GetComponent<enemy> ().life = Mathf.Clamp (otherObejct.GetComponent<enemy> ().life - damage, 0, 9999);
				game.controller.enemyHealth = otherObejct.GetComponent<enemy> ().health;
				game.controller.enemyMaxHealth = otherObejct.GetComponent<enemy> ().maxHealth;
				otherObejct.GetComponent<enemy>().OnHit();
				Destroy (gameObject, 0.3f);
			}
        }
    }
}
