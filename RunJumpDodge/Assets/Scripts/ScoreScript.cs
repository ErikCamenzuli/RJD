using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text text;

    private float score = 0.0f;
    private int difficulty = 1;
    private int maxDifficulty = 10;
    private int nextLevel = 10;

    // Update is called once per frame
    void Update()
    {
        if(score >= nextLevel)
        {
            Level();
        }

        score += Time.deltaTime * difficulty;

        //setting the text component to the score
        //initalizng score as a int value and convert the values after the . value of the float
        //to give a cleaner value
        text.text = ((int)score).ToString();
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

        Debug.Log(difficulty);

    }

}
