using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Water;

    //Water level starts in the negative as a buffer
    public float WaterLevel = -5f;
    [SerializeField] private float waterThreshold = 10f;

    public List<Hole> Holes = new();



    void Awake()
    {
        Game.Manager = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Water.transform.position = Vector3.Lerp(Water.transform.position, Vector3.up * WaterLevel, 0.1f * Time.deltaTime);
        CheckWaterLevel();
    }

    void CheckWaterLevel()
    {
        // Check if the water has reached the top.
        if (WaterLevel >= waterThreshold)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // End the game. The water has reached the top.
        // Display the game over screen.
        UIController.instance.GameOverScreen();
    }
}
