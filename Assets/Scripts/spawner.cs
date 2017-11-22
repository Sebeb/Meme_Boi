using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public float lightSpawnTime;
    float nextLightSpawn;
    GameObject tunnel;

	void Start () {
        game.controller.spawnZ = transform.position.z;
        tunnel = GameObject.Find("Tunnel");
		
	}

    void FixedUpdate()
    {

        #region Light Spawn
        if (Time.fixedTime>nextLightSpawn){
            nextLightSpawn += lightSpawnTime;
            GameObject light = Instantiate(Resources.Load("Light", typeof(GameObject)),transform.position,Quaternion.identity)as GameObject;
            light.transform.parent = tunnel.transform;
        }
#endregion
    }
}
