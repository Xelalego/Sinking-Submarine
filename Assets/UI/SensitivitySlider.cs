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
        if (PlayerPrefs.HasKey("MouseSensitivity")) slider.value = PlayerPrefs.GetFloat("MouseSensitivity");
        else UpdateSensitivity();
    }

    public void UpdateSensitivity()
    {
        PlayerPrefs.SetFloat("MouseSensitivity", slider.value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
