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
    [Range(0,200)]
    public float speed;
    [Range(0, 0.01f)]
    public float acceleration;
    public float upperBound, rightBound;
    [HideInInspector]
    public GameObject tunnel;
	public int score;
	public int lives;
	public enemy targetedEnemy;
    AudioSource audio;



    void Awake()
    {
        controller = this;
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        tunnel = GameObject.Find("Tunnel");
        audio = GetComponent<AudioSource>();
    }

    void Start () {
	}
	
	void Update () {
        speed += acceleration;
        if (lives>0)
            audio.pitch += (acceleration / 250);
        else
            if (audio.pitch > 0.15f)
                audio.pitch /= 1.004f;
	}
}
