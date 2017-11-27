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
    player player;
    public float spawnZ;
    [Range(0,200)]
    public float speed;
    public float timeSpeed = 1;
    [Range(0, 0.01f)]
    public float acceleration;
    public float upperBound, rightBound;
    [HideInInspector]
    public GameObject tunnel;
	public int score;
    public int multiplier;
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
    public GameObject gameOverText;
    public string[] gameOverMessages;
    int displayedScore=0;
    public float displayedEnemyHealth=0;



    void Awake()
    {
        controller = this;
        spawner = GameObject.Find("Spawner").GetComponent<spawner>();
        tunnel = GameObject.Find("Tunnel");
        audio = GetComponent<AudioSource>();
        player = GameObject.Find("Player").GetComponent<player>();
    }

    void Start () {
	}
	
	void Update () {
        #region Time + Speed
        speed += acceleration;
        Time.timeScale = timeSpeed;
        Time.fixedDeltaTime = timeSpeed * 0.02f;
        if (lives>0)
            timeSpeed = Mathf.MoveTowards(timeSpeed, 1, 0.4f*Time.deltaTime);
        else
            timeSpeed = Mathf.MoveTowards(timeSpeed, 0.2f, 0.4f * Time.deltaTime);

        if (lives>0)
            GetComponent<audioPitchSlowmo>().normalPitch -= (acceleration / 125);
#endregion

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
            displayedEnemyHealth = (int)Mathf.MoveTowards(displayedEnemyHealth, enemyHealth, 0.05f);
            enemyLifeBar.GetComponent<Slider>().value = displayedEnemyHealth / (float)maxEnemyHealth;
        }

        //Else hide Enemy Name and Health
        else
        {
            enemyNameText.SetActive(false);
            enemyLifeBar.SetActive(false);
        }

        //If Game Over activate GameOver Text and disable everything else
        if(lives == 0)
        {
            if (!player.invincible)
                Deactivate();
            audio.volume -= 0.001f;
        }

        displayedScore = (int)Mathf.MoveTowards(displayedScore, score, 0.1f);
        scoreText.GetComponent<Text>().text = displayedScore.ToString();

        if (Input.GetButtonDown("Start")&&lives<1)
            Application.LoadLevel(Application.loadedLevel);
            
	}


    void Deactivate(){
        player.invincible = true;
        enemyNameText.SetActive(false);
        enemyLifeBar.SetActive(false);
        scoreText.SetActive(false);
        gameOverText.SetActive(true);
        gameOverText.GetComponent<Text>().text = (gameOverMessages[Random.Range(0,gameOverMessages.Length)] + 
                                                  "\nscore: " + score+
                                                 "\npress start to continue.");
        Instantiate(Resources.Load("Music/Hide n Seek"));
    }
}
