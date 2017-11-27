using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class game : MonoBehaviour
{
	public int levels;
	[Range (0,5)]
	public int level;
	public static game controller;
    public static spawner spawner;
    public float spawnZ;
    [Range(0,200)]
    public float speed;
    [Range(0, 0.01f)]
    public float acceleration;
    public float upperBound, rightBound;
    [HideInInspector]
    public GameObject tunnel;
	public int score;
	public int lives;
	public enemy targetedEnemy;
    AudioSource audio;
    public int maxEnemyHealth;
    public int enemyHealth;
    public string enemyName;

    //UI stuff
    public GameObject enemyNameText;
    public GameObject scoreText;
    public GameObject enemyLifeBar;
    public GameObject[] playerLivesImages;
    public GameObject gameOverText;

    public Sprite playerLifeDisabled;

    void Awake()
    {
        controller = this;
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        tunnel = GameObject.Find("Tunnel");
        audio = GetComponent<AudioSource>();
    }

    void Start () {
	}
	
	void Update () {
        speed += acceleration;
        if (lives>0)
            audio.pitch += (acceleration / 250);
        else
            if (audio.pitch > 0.15f)
                audio.pitch /= 1.004f;

        //UI Updates

        //Check if Enemy passed the Player
        if (targetedEnemy != null && targetedEnemy.transform.position.z < 0)
        {
            targetedEnemy = null;
        }

        //If Player is fighting against an enemy
        if (targetedEnemy != null)
        {
            enemyName = targetedEnemy.name;
            enemyNameText.SetActive(true);
            enemyNameText.GetComponent<Text>().text = enemyName;

            enemyLifeBar.SetActive(true);
            enemyLifeBar.GetComponent<Slider>().value = (float)enemyHealth / (float)maxEnemyHealth;
        }
        //Else hide Enemy Name and Health
        else
        {
            enemyNameText.SetActive(false);
            enemyLifeBar.SetActive(false);
        }

        //Change Life Sprite to Life-Lost Sprite
        for(int i = playerLivesImages.Length; i > lives; i--)
        {
            if(!(playerLivesImages[i-1].GetComponent<Image>().sprite.Equals(playerLifeDisabled)))
                playerLivesImages[i-1].GetComponent<Image>().sprite = playerLifeDisabled;
        }

        //If Game Over activate GameOver Text and disable everything else
        if(lives == 0)
        {
            for (int i = 0; i < playerLivesImages.Length; i++)
            {
                playerLivesImages[i].SetActive(false);
            }
            enemyNameText.SetActive(false);
            enemyLifeBar.SetActive(false);
            scoreText.SetActive(false);

            gameOverText.SetActive(true);
            gameOverText.GetComponent<Text>().text = "Game Over\nScore: " + score;
        }
        
        scoreText.GetComponent<Text>().text = score.ToString();
	}
}
