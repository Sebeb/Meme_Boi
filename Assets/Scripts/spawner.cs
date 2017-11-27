using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    public float lightSpawnTime;
    float nextLightSpawn;
    public List <GameObject> enemyPool;
    public List<GameObject> SpawnQueue;
    public List<float> SpawnSchedule;


    void Start()
    {
        game.controller.spawnZ = transform.position.z;
		#region Populate Enemy Spawn Pool
		foreach (GameObject enemy in Resources.LoadAll<GameObject>("")) {
			if (enemy.GetComponent<spawnStats> () != null)
				enemyPool.Add (enemy);
		}
		#endregion

        PopulateSpawnList();
    }

    void PopulateSpawnList()
    {
        foreach (GameObject enemy in enemyPool)
        {
            AddEnemyToQueue(enemy);
        }
    }

    void AddEnemyToQueue(GameObject enemy)
    {
        spawnStats schedule = enemy.GetComponent<spawnStats>();

		if (schedule.spawnTimeMax[game.controller.level]!=0){
        float spawnTime = Time.time + Random.Range(schedule.spawnTimeMin[game.controller.level], schedule.spawnTimeMax[game.controller.level]);
        if (SpawnQueue.Count != 0)
        {
            for (int position = 0; position <= SpawnQueue.Count; position++)
            {
                if (position == SpawnQueue.Count)
                {
                    SpawnQueue.Add(enemy);
                    SpawnSchedule.Add(spawnTime);
                    break;
                }

                if (SpawnSchedule[position] > spawnTime && position < SpawnQueue.Count)
                {
                    SpawnSchedule.Insert(position, spawnTime);
                    SpawnQueue.Insert(position, enemy);
                    break;
                }
            }

        }
        else
        {
            SpawnQueue.Add(enemy);
            SpawnSchedule.Add(spawnTime);
        }
    }
	}

    void FixedUpdate()
    {
        #region Light Spawn
        if (Time.fixedTime > nextLightSpawn)
        {
            nextLightSpawn += lightSpawnTime;
            GameObject light = Instantiate(Resources.Load("Scenery/Light", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            light.transform.parent = game.controller.tunnel.transform;
        }
        #endregion

        #region Enemy Spawn

        if (Time.time > SpawnSchedule[0]){
            GameObject enemy = SpawnQueue[0];
            SpawnQueue.RemoveAt(0);
            SpawnSchedule.RemoveAt(0);
			if (enemy.GetComponent<spawnStats>().spawnProbibility[game.controller.level]>=Random.Range(0,101)){
            Vector2 enemySize = enemy.GetComponent<BoxCollider>().size;
            Vector3 position = new Vector3(Random.Range(-game.controller.rightBound + (enemySize.x / 2),
                                                        game.controller.rightBound - (enemySize.x / 2)),
                                           Random.Range(-game.controller.upperBound + (enemySize.y / 2),
                                                        game.controller.upperBound - (enemySize.y / 2)),
                                           transform.position.z);
            Instantiate(enemy, position, Quaternion.identity);
			}
            AddEnemyToQueue(enemy);
        }


#endregion
    }
}
