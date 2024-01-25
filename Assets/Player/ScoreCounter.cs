using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;
    public int score = 0;
    private int pointsToGive = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.SetText("SCORE: " + score.ToString());
    }

    public void AddToScore()
    {
        score += pointsToGive;
    }
}
