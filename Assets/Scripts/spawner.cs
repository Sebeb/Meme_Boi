using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public float lightSpawnTime;
    float nextLightSpawn;
    public GameObject[] enemyPool;


	void Start () {
        game.controller.spawnZ = transform.position.z;
        enemyPool = Resources.LoadAll<GameObject>("Enemies/");
	}

    void FixedUpdate()
    {

        #region Light Spawn
        if (Time.fixedTime>nextLightSpawn){
            nextLightSpawn += lightSpawnTime;
            GameObject light = Instantiate(Resources.Load("Light", typeof(GameObject)),transform.position,Quaternion.identity)as GameObject;
            light.transform.parent = game.controller.tunnel.transform;
        }
#endregion
    }
}
