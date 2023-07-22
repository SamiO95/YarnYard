using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer musicaudioMixer;
    public void SetMusicVolume(float musicvolume)
    {
        musicaudioMixer.SetFloat("MusicVolume", musicvolume);
    }

    public AudioMixer sfxaudioMixer;
    public void SetSFXVolume(float sfxvolume)
    {
        sfxaudioMixer.SetFloat("SFXVolume", sfxvolume);
    }
}
