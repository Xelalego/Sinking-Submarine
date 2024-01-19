using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private float StartTime = 0f;
    [Tooltip("Time from instantiation to severity increase")]
    [SerializeField]
    private float SeverityProgressionRate = 30f;
    private int Severity = 0;

    private void Start()
    {
        StartTime = Time.time;
        Game.Manager.Holes.Add(this);
    }

    void OnTriggerEnter(Collider other)
    {
        Pickup plug = other.gameObject.GetComponent<Pickup>();
        if (plug)
        {
            if (Game.Player.HeldItem == plug) Game.Player.HeldItem = null;
            plug.transform.position = transform.position;// Might be too jumpy
            plug.RigidBody.isKinematic = true;
            Destroy(plug.gameObject, 3f);// Destroy the plug after 3 seconds
            Destroy(gameObject, 3f);
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Time.time + SeverityProgressionRate >= StartTime)
        {
            Severity++;
            // Increase water level
            Game.Manager.WaterLevel += Severity;
            if (Severity >= 3)
            {
                print("Too late!");
                Destroy(gameObject);
            }
            StartTime += SeverityProgressionRate;
        }
    }

    void OnDestroy()
    {
        Game.Manager.Holes.Remove(this);
    }
}
