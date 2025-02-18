using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; // Necesitar pentru a folosi AudioMixer
using UnityEngine.UI;   // Necesitar pentru a folosi Slider-ul

public class VolumGame : MonoBehaviour
{
    public AudioMixer audioMixer;  // AudioMixer-ul nostru
    public Slider volumeSlider;    // Slider-ul UI pentru volum

    void Start()
    {
        // Inițializează slider-ul la valoarea curentă a volumului
        float currentVolume;
        if (audioMixer.GetFloat("MasterVolume", out currentVolume))
        {
            // Convertim valoarea din dB într-o valoare normală pentru slider
            volumeSlider.value = Mathf.Pow(10, currentVolume / 20);
        }

        // Adăugăm ascultătorul pentru modificarea volumului
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Evită erorile dacă volumul este prea mic
        if (volume <= 0.0001f) volume = 0.0001f;

        // Convertim valoarea slider-ului într-un volum în dB
        float dB = Mathf.Log10(volume) * 20;

        // Setează volumul în AudioMixer
        audioMixer.SetFloat("MasterVolume", dB);
    }
}
