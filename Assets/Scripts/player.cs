using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Range(0, 1)]
    public float movementSpeed;
    public Weapons currentWeapon;
    float reloadTime;
    public sfxManager fireSFX;


    void Start()
    {
        SwitchWeapon(Weapons.MNH);
    }

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && reloadTime <= Time.time)
        {
            Fire();
        }
    }

    void SwitchWeapon(Weapons weapon)
    {
        currentWeapon = weapon;
        switch (weapon)
        {
            case Weapons.MNH:
                GameObject soundManager = Instantiate(Resources.Load("Weapons/MNH/SFX Manager")) as GameObject;
                fireSFX = soundManager.GetComponent<sfxManager>();
                soundManager.transform.parent = transform;
                break;
        }
    }

    void Fire()
    {
        switch (currentWeapon)
        {
            case (Weapons.MNH):
                GameObject bullet = Resources.Load("Weapons/MNH/Bullet") as GameObject;
                reloadTime = Time.time + bullet.GetComponent<basicBullet>().reloadTime;
                GameObject spawnedBullet = Instantiate(bullet, transform.position + new Vector3(0, 0, 0.5f), bullet.transform.rotation);
                spawnedBullet.transform.parent = game.controller.tunnel.transform;
                fireSFX.PlaySound();
                break;
        }
    }

    void FixedUpdate()
    {
		#region Movement
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * movementSpeed, -game.controller.rightBound, game.controller.rightBound),
            Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical") * movementSpeed, -game.controller.upperBound, game.controller.upperBound), 0);
		#endregion
    }
}

public enum Weapons { MNH, Other };
