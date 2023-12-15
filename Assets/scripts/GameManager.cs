using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float initialGameSpeed = 5f;
    public float incrzGameSpeed = 0.5f;
    public float gameSpeed { get; private set; }
    private Movement player;
    private Spawn spawner;
    public Button retryButton;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI scoreText;
    float score;
    float hScore = 0f;

    private void Awake()
    {
        if (Instance == null) // if it is not present then put instance
        {
            Instance = this;
        }
        else // if due to any reason another one created then destroy it coz we need only one
        {
            DestroyImmediate(gameObject);
        }
        player = FindObjectOfType<Movement>();
        spawner = FindObjectOfType<Spawn>();

    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        newGame();
        player = FindObjectOfType<Movement>();
        spawner = FindObjectOfType<Spawn>();
    }

    public void newGame()
    {
        animateObjects[] obstacles = FindObjectsOfType<animateObjects>();  // this is to clean spawned obstcle , destroy(obstacle)-> destroy only script of named obstacle
        foreach (var obj in obstacles)            // to destroy all, like sprite renderer , script etc... use obstacle.gameObject
        {
            Destroy(obj.gameObject);            // we are collecting all obstacles in an array which contain script animateObjects and destroy them all using .gameObject
        }


        score = 0;
        gameSpeed = initialGameSpeed;
        enabled = true;
        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        highScore.text = Mathf.FloorToInt(hScore).ToString("D5");
    }

    public void gameOver()
    {
        gameSpeed = 0f;
        enabled = false;   // this will disable GameManager 

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        highScore.text = Mathf.FloorToInt(hScore).ToString("D5");
    }

    private void Update()
    {
        gameSpeed += incrzGameSpeed * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");  // c# built-in function D5 means it will show number till 5 digit place, D4 to 4 place so on....
        //                                  FloorToInt shows one less value i.e. 7.7 to 7 or 7.4 to 7, but RoundToInt will fluatactes i.e. 7.9 to 8 , 7.4 to 7

        if (score > hScore)
        {
            hScore = score;
        }

    }

}
