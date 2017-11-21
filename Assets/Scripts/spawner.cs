using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public float lightSpawnTime;
    float nextLightSpawn;

	void Start () {
		
	}

    void FixedUpdate()
    {

        #region Light Spawn
        if (Time.fixedTime>nextLightSpawn){
            nextLightSpawn += lightSpawnTime;
            Instantiate(Resources.Load("Light", typeof(GameObject)),transform.position,Quaternion.identity);
        }
#endregion
    }
}
