using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    protected float timer;
    public int delayAmount = 1;

    //Allows for ScoreManager.cs to be referenced in other files
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Sets inital high score to 0
        highscore = PlayerPrefs.GetInt("highscore", 0);

        //Displays score and high score texts
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "High Score: " + highscore.ToString();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= delayAmount)
        {
            timer = 0f;
            score ++;
            scoreText.text = "Score: " + score.ToString();
        }
    }


    public void AddPoint()
    {
        //Adds points to score when collecting seed
        score += 10;
        scoreText.text = "Score: " + score.ToString();

        //Sets new high scores
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }

}

