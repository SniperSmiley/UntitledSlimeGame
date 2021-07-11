using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{

    public AudioMixer audioMixer;
       
    public void SetMasterVolumeReal(float volume) { audioMixer.SetFloat("Volume", volume);  }

    public void SetMusicVolume(float volume) {audioMixer.SetFloat("MusicVolume", volume); }

    public void SetEffectsVolume(float volume) { audioMixer.SetFloat("EffectsVolume", volume); }
       
}
