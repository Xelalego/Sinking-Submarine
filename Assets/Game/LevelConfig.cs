using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelConfig
{
    [Tooltip("The time in seconds that the level lasts for")]
    public float TimeLimit = 60f;
    [HideInInspector]
    public int LevelNumber = 1;
    [Tooltip("The minimum amount of time in seconds it takes for a new hole to spawn")]
    public float MinHoleSpawnRate = 30f;
    [Tooltip("The maximum amount of time in seconds it takes for a new hole to spawn")]
    public float MaxHoleSpawnRate = 50f;
    [Tooltip("A multiplier in meters per second for the rising water speed")]
    public float RisingRate = 0.01f;
    [Tooltip("The time in seconds it takes for the Maximum Hole value to increase by 1")]
    public float MaxHoleIncreaseRate = 60f;
}
