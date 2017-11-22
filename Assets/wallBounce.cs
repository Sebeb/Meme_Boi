using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallBounce : MonoBehaviour {

	Rigidbody rigidBody;
	public float movementSpeed;

	void Awake (){
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Start () {
		rigidBody.velocity = new Vector3 (movementSpeed, movementSpeed, 0);
	}

	void Update () {
		if (rigidBody.velocity.x < 0)
			transform.localScale = new Vector3(-1,1,1);
		else
			transform.localScale = new Vector3(1,1,1);
			
	}
}
