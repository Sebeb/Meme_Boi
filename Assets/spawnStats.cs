using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnStats : MonoBehaviour {
	int[] spawnProbability;

	void Awake () {
		spawnProbability = new int[game.controller.levels + 1];	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
