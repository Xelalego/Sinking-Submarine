using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(0.5f) * 20);
        //mixer.GetFloat("MasterVolume", out float volume);
        //slider.value = Mathf.Pow(10f, Mathf.Log(volume)) / 20f;
    }

    public void UpdateVolume()
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(slider.value) * 20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
