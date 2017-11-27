using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class livesHUD : MonoBehaviour {

    public GameObject life;

	void Start () {
        for (int i = 0; i < game.controller.lives; i++)
            AddLife();
       
	}
	
    void AddLife(){
        GameObject newLife = Instantiate(life);
        newLife.transform.parent = transform;
    }

	void Update () {
        if (transform.childCount < game.controller.lives)
            AddLife();
        if (transform.childCount > game.controller.lives)
            Destroy(transform.GetChild(transform.childCount - 1).gameObject);
		
	}
}
