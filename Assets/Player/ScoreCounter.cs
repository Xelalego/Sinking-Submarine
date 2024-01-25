using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private float StartTime;

    public TMP_Text scoreText;
    public static int score = 0;
    public static int holeScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        score = (int)((Time.time - StartTime) / 10) * 100 + holeScore;
        scoreText.SetText("SCORE: " + score.ToString());
    }
}
