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
    public int Severity = 0;

    [SerializeField]
    private ParticleSystem Particles;
    [SerializeField]
    private Animator animator;

    private bool Plugged = false;

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
        if (!plug) return;
        if (plug && PlugFits(plug))
        {
            PlugHole(plug);
        }
    }

    private void PlugHole(Pickup plug)
    {
        ScoreCounter.holeScore += 250 + 50*Severity;
        if (Game.Player.HeldItem == plug) Game.Player.HeldItem = null;
        plug.transform.position = transform.position;// Might be too jumpy
        plug.RigidBody.isKinematic = true;
        if (animator) animator.Play("RemoveHole");
        Destroy(plug);
        Destroy(plug.gameObject, 30f);
        Destroy(gameObject, 30f);
        Destroy(this);
        Plugged = true;
    }

    private bool PlugFits(Pickup plug)
    {
        if (Severity == 3) return plug.size == Pickup.Size.Large;
        else if (Severity == 2) return plug.size == Pickup.Size.Medium;
        else if (Severity == 1) return plug.size == Pickup.Size.Medium || plug.size == Pickup.Size.Small;
        else return plug.size == Pickup.Size.Small;
    }

    private void Update()
    {
        if (Plugged) return;
        if (Time.time >= StartTime + SeverityProgressionRate && Severity < 3)// Severity capped at 3
        {
            Severity++;
            ParticleSystem.EmissionModule emissionModule = Particles.emission;
            emissionModule.rateOverTime = Severity * 40f + 15f;
            StartTime = Time.time + SeverityProgressionRate;
        }
    }

    void OnDestroy()
    {
        Game.Manager.Holes.Remove(this);
        Game.Manager.HoleSpawnpoints.Add(transform.parent);
    }
}
