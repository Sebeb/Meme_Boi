using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    [Range(0,1)]
    public float movementSpeed;
	public CurrentWeapon currentWeapon;
	public float reloadTime;


	void Start () {
		
	}
	
	void Update (){
		if (Input.GetAxis ("Fire1")>0 && reloadTime <= Time.time) {
			Fire ();
		}
	}

	void Fire(){
		switch (currentWeapon) {
		case (CurrentWeapon.Texture):
			GameObject bullet = Resources.Load ("Weapons/TexNotFound") as GameObject;
			reloadTime = Time.time + bullet.GetComponent<basicBullet> ().reloadTime;
			Instantiate (bullet,transform.position,bullet.transform.rotation);
			break;
		}
	}

	void FixedUpdate () {
        transform.position += new Vector3(Input.GetAxis("Horizontal")*movementSpeed, 
                                          Input.GetAxis("Vertical")*movementSpeed,0);
		
	}
}

public enum CurrentWeapon {Texture, Other};
