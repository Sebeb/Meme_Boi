using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
    public static game controller;
    public static spawner spawner;

    public float speed;

    void Awake()
    {
        controller = this;
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
