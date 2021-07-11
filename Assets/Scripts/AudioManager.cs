using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {
    // Play background music, manage what clips are being played in general. 
    public GameObject SoundEffectsGo;
    public AudioSource maintrack;

    // DONT TOUCH YOU WILL REGRET
    public AudioClip GrossDontTouch;
    //

    public AudioMixerGroup mixer;
    public int NumberOfAudioSources = 25;

    public static List<AudioSource> AudioSourcesList = new List<AudioSource>();
    public List<AudioClip> InteractionAudioClips;

    private void Awake() {
        AudioSource source;
        for (int i = 0; i < NumberOfAudioSources; i++) {
            source = SoundEffectsGo.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = mixer;
            AudioSourcesList.Add(source);
        }
    }

    public void PlaySquelchSoundEffect() {

        int clip = Random.Range(0, 6);

        StartCoroutine(PlayEffect(InteractionAudioClips[clip]));
    }

    public void PlayMMMMSoundEffect() {  StartCoroutine(PlayEffect(GrossDontTouch)); }
      
    public static IEnumerator PlayEffect(AudioClip clip) {

        AudioSource _audioSource = null;
        foreach (AudioSource source in AudioSourcesList) {
            if (source.clip == null) {
                // Not being used.
                _audioSource = source;
                break;
            }
        }

        if (_audioSource == null) { Debug.Log("Audio source ran out of sources."); }
        else {

            Debug.Log("Play");
            _audioSource.clip = clip;
            _audioSource.Play();

            yield return new WaitForSeconds(_audioSource.clip.length);

            _audioSource.clip = null;

        }
    }
}
