using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", Mathf.Log10(0.5f) * 20);
        //mixer.GetFloat("MasterVolume", out float volume);
        //slider.value = Mathf.Pow(10f, Mathf.Log(volume)) / 20f;
    }

    public void UpdateSensitivity()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", Mathf.Log10(slider.value) * 20);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
