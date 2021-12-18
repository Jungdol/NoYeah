using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    [Header("오디오 믹서")]
    public AudioMixer mixer;

    [Header("소리")]
    public Slider MasterSoundSlider;
    public Slider BGMSoundSlider;
    public Slider EffectSoundSlider;
    [Header("버튼 소리")]
    public string buttonSound;

    AudioManager theAudio;

    void Start()
    {
        theAudio = FindObjectOfType<AudioManager>();
        DataCreate();
    }
    void DataCreate()
    {
        SoundInt();
    }

    public void SettingClear()
    {
        theAudio.Play(buttonSound);

        PlayerPrefs.DeleteAll();
        DataCreate();
    }

    public void MasterSoundSlide(float _value)
    {
        PlayerPrefs.SetInt("MasterSoundVolume", (int)_value);

        if (_value == -40f) mixer.SetFloat("Master", _value - 80);
        else mixer.SetFloat("Master", _value);
    }

    public void BGMSoundSlide(float _value)
    {
        PlayerPrefs.SetInt("BGMSoundVolume", (int)_value);
        if (_value == -40f) mixer.SetFloat("BGM", _value - 80);
        else mixer.SetFloat("BGM", _value);
    }

    public void EffectSoundSlide(float _value)
    {
        PlayerPrefs.SetInt("EffectSoundVolume", (int)_value);
        if (_value == -40f) mixer.SetFloat("SFX", _value - 80);
        else mixer.SetFloat("SFX", _value);
    }

    void SoundInt()
    {
        if (!PlayerPrefs.HasKey("MasterSoundVolume"))
        {
            PlayerPrefs.HasKey("MasterSoundVolume");
            PlayerPrefs.SetInt("MasterSoundVolume", 50);
        }
        if (!PlayerPrefs.HasKey("BGMSoundVolume"))
        {
            PlayerPrefs.HasKey("BGMSoundVolume");
            PlayerPrefs.SetInt("BGMSoundVolume", 100);
        }
        if (!PlayerPrefs.HasKey("EffectSoundVolume"))
        {
            PlayerPrefs.HasKey("EffectSoundVolume");
            PlayerPrefs.SetInt("EffectSoundVolume", 100);
        }

        MasterSoundSlider.value = PlayerPrefs.GetInt("MasterSoundVolume");
        if (PlayerPrefs.GetInt("MasterSoundVolume") == -40f) mixer.SetFloat("Master", PlayerPrefs.GetInt("MasterSoundVolume") - 80);
        else mixer.SetFloat("Master", PlayerPrefs.GetInt("MasterSoundVolume"));

        BGMSoundSlider.value = PlayerPrefs.GetInt("BGMSoundVolume");
        if (PlayerPrefs.GetInt("BGMSoundVolume") == -40f) mixer.SetFloat("BGM", PlayerPrefs.GetInt("BGMSoundVolume") - 80);
        else mixer.SetFloat("BGM", PlayerPrefs.GetInt("BGMSoundVolume"));

        EffectSoundSlider.value = PlayerPrefs.GetInt("EffectSoundVolume");
        if (PlayerPrefs.GetInt("EffectSoundVolume") == -40f) mixer.SetFloat("SFX", PlayerPrefs.GetInt("EffectSoundVolume") - 80);
        else mixer.SetFloat("SFX", PlayerPrefs.GetInt("EffectSoundVolume"));
    }
}
