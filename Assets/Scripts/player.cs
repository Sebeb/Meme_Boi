using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [Range(0, 1)]
    public float movementSpeed;
    public Weapons currentWeapon;
    public bool invincible;
    float reloadTime;
    public sfxManager fireSFX;
    public bool mouseControl;
    Vector3 velocity = Vector3.zero;
    public bool dead;


    void OnTriggerEnter(Collider enemyCollider)
    {
        if (enemyCollider.tag == "Enemies" && !enemyCollider.gameObject.GetComponent<enemy>().dead && !invincible)
        {
            OnHit();
        }
        if (enemyCollider.tag == "Pickup")
        {
           //pickup!
        }
    }

    void Start()
    {
        SwitchWeapon(Weapons.MNH);
    }

    void OnHit(){
        game.controller.lives--;
        if (game.controller.lives <= 0)
            dead = true;
        game.controller.timeSpeed = 0.2f;
    }

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && reloadTime <= Time.time && game.controller.lives != 0)
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
                GameObject soundManager = Instantiate(Resources.Load("SFX Manager")) as GameObject;
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
        if (Input.mousePosition.x > 0 && Input.mousePosition.x < Screen.height * 2 && Input.mousePosition.y > 0 && Input.mousePosition.y < Screen.height * 2)
        {
            if (Input.GetMouseButtonDown(0))
                mouseControl = true;
        }
        if (Input.GetAxis("Horizontal") != 0 ||
            Input.GetAxis("Vertical") != 0)
            mouseControl = false;


        #region Movement
        if (!dead)
        {
            if (!mouseControl)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x + Input.GetAxis("Horizontal") * movementSpeed, -game.controller.rightBound, game.controller.rightBound),
                    Mathf.Clamp(transform.position.y + Input.GetAxis("Vertical") * movementSpeed, -game.controller.upperBound, game.controller.upperBound), 0);
            }
            else
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                Vector3 targetPosition = new Vector3(Mathf.Clamp(-game.controller.rightBound + ((Input.mousePosition.x / Screen.width)) * game.controller.rightBound * 2, -game.controller.rightBound, game.controller.rightBound),
                                                 Mathf.Clamp(-game.controller.upperBound + ((Input.mousePosition.y / Screen.height)) * game.controller.upperBound * 2, -game.controller.upperBound, game.controller.upperBound), 0);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.01f, movementSpeed * 100);
            }
            #endregion
        }

        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(1.1f, -1.8f, 0), ref velocity, 0.01f, movementSpeed * 10);
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
    }  
}

public enum Weapons { MNH, Wow };
