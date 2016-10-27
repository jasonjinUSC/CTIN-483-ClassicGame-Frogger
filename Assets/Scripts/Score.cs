using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	int score;
    int highScore;
	Text text;
	// Use this for initialization
	void Awake() 
	{
	
		text = GetComponent<Text> ();
		score = 0;
        highScore = 2000;

        updateScore();
	}
	
    public void resetAndChangeHigh()
    {
        if(score > highScore)
        {
            highScore = score;
        }
        score = 0;

        updateScore();
    }
	// Update is called once per frame
	void Update () {

		
	
	}

    void updateScore()
    {
        string scoreText;
        if(score < 10)
        {
            scoreText = "0000" + score;
        }
        else if(score < 100)
        {
            scoreText = "000" + score;
        }
        else if(score < 1000)
        {
            scoreText = "00" + score;
        }
        else if(score < 10000)
        {
            scoreText = "0" + score;
        }
        else
        {
            scoreText = "" + score;
        }

        string highScoreText;
        if (highScore < 10)
        {
            highScoreText = "0000" + highScore;
        }
        else if (highScore < 100)
        {
            highScoreText = "000" + highScore;
        }
        else if (highScore < 1000)
        {
            highScoreText = "00" + highScore;
        }
        else if (highScore < 10000)
        {
            highScoreText = "0" + highScore;
        }
        else
        {
            highScoreText = "" + highScore;
        }

        text.text = scoreText + "\t\t " + highScoreText;
    }

    public void addScore(int i)
    {
        score += i;
        updateScore();
    }
}
