using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public List<AudioClip> SFX = new();

    public bool Locked = false;
    public bool Opened = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Toggle()
    {
        if (Locked) return;
        if (Opened) Close();
        else Open();
    }

    public bool Open()
    {
        if (Locked) return false;
        if (animator && !Opened) animator.Play("Door Open");
        if (audioSource && SFX.Count > 0) audioSource.PlayOneShot(SFX[Random.Range(0, SFX.Count)]);
        Opened = true;
        // Door automatically closes after 5 seconds
        Invoke(nameof(Close), 5f);
        return true;
    }

    public void Close()
    {
        if (animator && Opened) animator.Play("Door Close");
        if (audioSource && SFX.Count > 0) audioSource.PlayOneShot(SFX[Random.Range(0, SFX.Count)]);
        Opened = false;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
