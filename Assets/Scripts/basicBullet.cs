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
	

	void Update () {
		
	}
}
