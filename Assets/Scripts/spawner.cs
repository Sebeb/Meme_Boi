using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public float lightSpawnTime;
    float nextLightSpawn;
    public GameObject[] enemyPool;
	public List<float> SpawnQueue;
	public List<GameObject> SpawnSchedule;


	void Start () {
        game.controller.spawnZ = transform.position.z;
        enemyPool = Resources.LoadAll<GameObject>("Enemies/");
		PopulateSpawnList ();
	}

	void PopulateSpawnList(){
		foreach (GameObject enemy in enemyPool) {
			
		}
	}

	void AddEnemyToQueue(GameObject enemy){
		spawnStats schedule = enemy.GetComponent<spawnStats> ();
		float spawnTime = Random.Range (Time.time + schedule.spawnTimeMin, Time.time + schedule.spawnTimeMax);
		if (SpawnQueue.Count != 0) {
			for (int position = 0; position < SpawnQueue.Count; position++) {
				if (SpawnQueue[position]>spawnTime;
			}
			
		} else {
			SpawnQueue.Add (enemy);
			SpawnSchedule.Add (spawnTime);
		}
	}

    void FixedUpdate()
    {
        #region Light Spawn
        if (Time.fixedTime>nextLightSpawn){
            nextLightSpawn += lightSpawnTime;
            GameObject light = Instantiate(Resources.Load("Light", typeof(GameObject)),transform.position,Quaternion.identity) as GameObject;
            light.transform.parent = game.controller.tunnel.transform;
        }
#endregion
    }
}
