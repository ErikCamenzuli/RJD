﻿using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //referencing the text inside unity
    public Text text;
    public Text multiplier;
    public Text tokenText;
    public Text highScore;

    private int tokens;
    private float score = 0.0f;                 // - scoring
    private int difficulty = 1;                 // - how hard a level is
    private int maxDifficulty = 100;            // - max difficulty
    private int nextLevel = 1000;                 // - how much score is needed for next level 


    void Start()
    {
       // highScore.text = PlayerPrefs.GetInt("Highscore", 0).ToString();
    }


    // Update is called once per frame
    void Update()
    {
        //checking if the score is greater than the next level
        //then calls the level
        if(score >= nextLevel)
        {
            Level();
        }
        
        //increasing score over time then multipling by whatever the difficulty level is
        score += Time.deltaTime * difficulty;

        //text.text = score.ToString();
       // if(score > PlayerPrefs.GetInt("Highscore", 0))
       // {
       //     PlayerPrefs.SetInt("Highscore", (int)score);
       //     highScore.text = score.ToString();
       // }
       // else
       // {
       //     return;
       // }

        //setting the text component to the score
        //initalizng score as a int value and convert the values after the . value of the float
        //to give a cleaner value + doing error checks
        if (text == null)
        {
            return;
        }
        text.text = ((int)score).ToString();

        if(multiplier == null)
        {
            return;
        }
        multiplier.text = "x " + (difficulty).ToString();

        if(tokenText == null)
        { 
            return;
        }
        tokenText.text = "Tokens Collected: " + (tokens).ToString();

    }

    void Level()
    {
        //checking if the difficulty is at it's max and returns nothing
        if(difficulty == maxDifficulty)
        {
            return;
        }

        //increasing difficulty
        nextLevel *= 2;
        difficulty++;

        //calling the increased speed function from the player movement
        GetComponent<PlayerMovement>().IncreasedSpeed(difficulty);
    }

    private void OnTriggerEnter(Collider other)
    {
        //checking if the player has interacted with the coin
        if(other.tag == "Coin")
        {
            //add points 
            score += 100;
            //add tokens
            tokens++;
            //destroys object
            Destroy(other.gameObject);
        }
    }


}
