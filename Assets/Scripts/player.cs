using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    [Range(0,1)]
    public float movementSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*movementSpeed, 
                                          Input.GetAxis("Vertical")*movementSpeed,0);
		
	}
}
