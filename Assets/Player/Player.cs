using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxReach = 2.5f;

    public FirstPersonCamera CameraController;
    public Movement Movement;

    void Awake()
    {
        Game.Player = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
