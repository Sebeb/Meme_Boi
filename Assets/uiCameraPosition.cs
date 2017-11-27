using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiCameraPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Screen.width/2, Screen.height/2,transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
