using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBullet : MonoBehaviour {

	Rigidbody rigidBody;
	public float speed;
	public float reloadTime;
	public int damage;

	void Awake(){
		rigidBody = GetComponent<Rigidbody> ();
	}

	void Start () {
		rigidBody.velocity = new Vector3 (0, 0, speed);
	}
	

    void FixedUpdate()
    {
        if (transform.position.z > game.controller.spawnZ)
            Destroy(gameObject);
		if (rigidBody.velocity.z < speed)
			rigidBody.velocity = new Vector3 (0, 0, speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<enemy>()!=null){
            GameObject otherObejct = collision.gameObject;
			if (!otherObejct.GetComponent<enemy> ().dead) {
                otherObejct.GetComponent<enemy> ().health = Mathf.Clamp (otherObejct.GetComponent<enemy> ().health - damage, 0, otherObejct.GetComponent<enemy>().maxHealth);
                if (otherObejct.GetComponent<enemy>().health != 0)
                {
                    DestroyObject(gameObject);
                    game.controller.targetedEnemy = otherObejct.GetComponent<enemy>();
                }
				otherObejct.GetComponent<enemy>().OnHit();
                Destroy(gameObject, 0.03f);
			}
        }
    }
}
