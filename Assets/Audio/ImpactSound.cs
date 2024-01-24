using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioSource audioSource;
    public Rigidbody rigidBody;
    public List<AudioClip> ImpactClips = new();

    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource && rigidBody && ImpactClips.Count > 0)
        {
            float volume = collision.relativeVelocity.magnitude / 100f;
            audioSource.PlayOneShot(ImpactClips[Random.Range(0, ImpactClips.Count)], volume);
        }
    }
}
