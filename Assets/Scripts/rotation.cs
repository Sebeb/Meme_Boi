using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    public float rotationSpeed;
	void Start () {
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
	}
	
	void Update () {
        transform.rotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y+rotationSpeed, 0);	
	}
}
