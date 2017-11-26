using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class renderQueue : MonoBehaviour {
    public int position;

	// Use this for initialization
	void Start () {
        GetComponent<MeshRenderer>().material.renderQueue=position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
