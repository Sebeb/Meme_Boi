using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour
{
	public int levels;
	[Range (0,5)]
	public int level;
	public static game controller;
    public static spawner spawner;
    public float spawnZ;
    public float speed;
    public float upperBound, rightBound;
    [HideInInspector]
    public GameObject tunnel;
	public int score;
	public int lives;
	public enemy targetedEnemy;



    void Awake()
    {
        controller = this;
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        tunnel = GameObject.Find("Tunnel");
    }

    void Start () {
	}
	
	void Update () {
		
	}
}
