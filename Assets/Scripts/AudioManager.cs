using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Play background music, manage what clips are being played in general. 
    public AudioSource SoundEffectsGo;

    public List<AudioClip> InteractionAudioClips;


    public void PlaySoundEffect() {
   
        int clip = Random.Range(0, 6);
        Debug.Log("Clip played" + clip);
        SoundEffectsGo.clip = InteractionAudioClips[clip];
        SoundEffectsGo.Play();
    }


}
