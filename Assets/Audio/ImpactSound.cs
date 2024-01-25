using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactSound : MonoBehaviour
{
    public AudioSource audioSource;
    public Rigidbody rigidBody;
    public List<AudioClip> ImpactClips = new();

    private Vector3 LastPosition = new();

    public float Buffer = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource && rigidBody && ImpactClips.Count > 0 && Vector3.Distance(transform.position, LastPosition) > Time.deltaTime * Buffer)
        {
            float volume = collision.relativeVelocity.magnitude / 2f;
            audioSource.PlayOneShot(ImpactClips[Random.Range(0, ImpactClips.Count)], volume);
        }
    }

    private void LateUpdate()
    {
        LastPosition = transform.position;
    }
}
