using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    private PlayerProgress playerProgress;

    public GameObject newhighScore;
    public Text highScoreText;
    public Text startHighScore;
    private int highScore = 0;
    public static GameControl instance;
    public GameObject gameOverText;
    public bool gameOver = false;
    public Text scoreText;
    private int score = 0;

    // Use this for initialization

    void Awake()
    {

        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }
    void Start()
    {

       
        highScore = PlayerPrefs.GetInt("highestScore", highScore);
        highScoreText.text = "Highest Score:" + " " + highScore.ToString();
        startHighScore.text = "Highest Score:" + " " + highScore.ToString();
        
    }
    void Update()
    {
        if (gameOver && Input.GetMouseButtonDown(0))
        {
            //...reload the current scene.
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
    }
    public void PlayerScored()
    {
        
        if (gameOver)
        {
            
            return;
        }
        score++;
        scoreText.text = score.ToString();
        
        
       
    }

    public void PlayerDied()
    {
       
        gameOverText.SetActive(true);
        gameOver = true;
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "Highest Score:" + " " + score.ToString();
            PlayerPrefs.SetInt("highestScore", highScore);
            newhighScore.SetActive(true);
        }
    }   
   
}