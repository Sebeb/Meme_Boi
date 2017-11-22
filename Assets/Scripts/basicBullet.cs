using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBullet : MonoBehaviour {

	Rigidbody rigidBody;
	public float speed;
	public float reloadTime;

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
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<enemy>()!=null){
            GameObject otherObejct = collision.gameObject;
            otherObejct.GetComponent<enemy>().OnHit();
            Destroy(gameObject, 0.3f);
        }
    }
}
