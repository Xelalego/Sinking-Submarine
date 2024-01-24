using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Water;

    //Water level starts in the negative as a buffer
    public float WaterLevel = -5f;
    [SerializeField] private float waterThreshold = 10f;

    public List<Transform> HoleSpawnpoints = new();

    public List<Hole> Holes = new();

    private float NextHole = 10f;
    public float MinHoleSpawnRate = 30f;
    public float MaxHoleSpawnRate = 50f;

    [SerializeField]
    private GameObject HolePrefab;


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
        if (Time.time >= NextHole && Holes.Count < (int)(Time.time/60) + 5 && HoleSpawnpoints.Count > 0)
        {
            GameObject hole = Instantiate(HolePrefab);
            Transform holeSpawn = HoleSpawnpoints[Random.Range(0, HoleSpawnpoints.Count)];
            HoleSpawnpoints.Remove(holeSpawn);
            hole.transform.SetParent(holeSpawn);// Set parent to an unused Hole Spawner
            hole.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            NextHole = Time.time + Random.Range(MinHoleSpawnRate, MaxHoleSpawnRate);
        }
        int totalHoleSeverity = 0;
        foreach (Hole hole in Holes)
        {
            totalHoleSeverity += hole.Severity;
        }
        WaterLevel += 0.01f * (totalHoleSeverity - 3) * Time.deltaTime;
        WaterLevel = Mathf.Max(WaterLevel, -1f);
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
        var UIInstance = GameObject.Find("UI Canvas").GetComponent<UIController>();
        UIInstance.GameOverScreen();
    }
}
