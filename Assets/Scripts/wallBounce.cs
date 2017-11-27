using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounce : MonoBehaviour {

	Rigidbody rigidBody;
	public float movementSpeed;
	enemy enemy;

	void Awake (){
		rigidBody = GetComponent<Rigidbody> ();
		enemy = GetComponent<enemy> ();
	}

	void Start () {
		rigidBody.velocity = new Vector3 (movementSpeed, movementSpeed, 0);
	}

	void Update () {
		if (!enemy.dead) {
			if (rigidBody.velocity.x < 0)
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
			else
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
		}
	}
}
