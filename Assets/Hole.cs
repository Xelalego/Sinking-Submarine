using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private float StartTime = 0f;
    [Tooltip("Time from instantiation to severity increase")]
    [SerializeField]
    private float SeverityProgressionRate = 30f;
    private int Severity = 0;

    [SerializeField]
    private ParticleSystem Particles;

    private void Start()
    {
        StartTime = Time.time;
        Game.Manager.Holes.Add(this);
        ParticleSystem.EmissionModule emissionModule = Particles.emission;
        emissionModule.rateOverTime = Severity * 40f + 15f;
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
        // Increase water level
        Game.Manager.WaterLevel += Mathf.Max(0, (Severity-1)/100f * Time.deltaTime);
        if (Time.time >= StartTime + SeverityProgressionRate && Severity < 3)// Severity capped at 3
        {
            Severity++;
            ParticleSystem.EmissionModule emissionModule = Particles.emission;
            emissionModule.rateOverTime = Severity * 40f + 15f;
            if (Severity >= 3)
            {
                print("Too late!");
                //Destroy(gameObject);
                // Potentially lock off room?
            }
            StartTime = Time.time + SeverityProgressionRate;
        }
    }

    void OnDestroy()
    {
        Game.Manager.Holes.Remove(this);
        Game.Manager.HoleSpawnpoints.Add(transform.parent);
    }
}
