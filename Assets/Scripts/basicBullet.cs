using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicBullet : MonoBehaviour {

	Rigidbody rigidBody;
	public float speed;
	public float reloadTime;
	public int damage;
    MeshRenderer texture;
    float a;

	void Awake(){
		rigidBody = GetComponent<Rigidbody> ();
        texture = GetComponent<MeshRenderer>();
        texture.material.color = new Color(1, 1, 1, a);
	}

	void Start () {
		rigidBody.velocity = new Vector3 (0, 0, speed);
	}
	

    void FixedUpdate()
    {
        if (a<1){
            a = Mathf.Clamp(a+0.5f,0,1);
            texture.material.color = new Color(1, 1, 1, a);
        }
        if (transform.position.z > game.controller.spawnZ)
            Destroy(gameObject);
		if (rigidBody.velocity.z < speed)
			rigidBody.velocity = new Vector3 (0, 0, speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<enemy>() != null)
        {
            GameObject otherObejct = collision.gameObject;
            if (!otherObejct.GetComponent<enemy>().OnHit(damage))
                Destroy(gameObject);
            }
    }
}
