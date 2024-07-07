using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    public void SetMusicEnabled(bool enabled)
    {
        Music.enabled = enabled;
    }

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
