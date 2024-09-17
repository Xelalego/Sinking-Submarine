using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelConfig
{
    public float TimeLimit = 60f;
    [HideInInspector]
    public int LevelNumber = 1;
}
