using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour {

    public static AudioManager manager;

    // Play background music, manage what clips are being played in general. 
    public GameObject SoundEffectsGo;
    

    // Move this shit
    // DONT TOUCH YOU WILL REGRET
    public AudioClip GrossDontTouch;
    //

    public AudioMixerGroup EffectsMixer;
    public int NumberOfAudioSources = 25;

    [Header("Music Related")]
    public GameObject MusicGo;
    public float MusicBlendDuration = 4f;

    public AudioMixer MusicMixer;
    public string[] MusicMixersParamater;
    public static int CurrentMixerInt;
    public AudioSource HavenSource;


    public static List<AudioSource> AudioSourcesList = new List<AudioSource>();
    public List<AudioClip> InteractionAudioClips;

    private static bool HasRanStart = false;
   

    public enum Scenes {
        StartMenu,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6
    }

    private void Awake() {

        if (manager != null) { Destroy(this); }
        else { manager = this; }

        if (HasRanStart) { return;  }

        AudioSource source;
        for (int i = 0; i < NumberOfAudioSources; i++) {
            source = SoundEffectsGo.AddComponent<AudioSource>();
            source.outputAudioMixerGroup = EffectsMixer;
            AudioSourcesList.Add(source);
        }


        CurrentMixerInt = 0;

        SceneManagerScript.SceneChanged += OnSceneChange;

    }

    private void Start() {
       if (HasRanStart == true) { return;  }

       StartCoroutine(FadeMusicInOut(MusicMixer, MusicMixersParamater[0] ,1f, 100));

       HasRanStart = true;
    }

    public void PlaySquelchSoundEffect() {

        int clip = Random.Range(0, 6);

        StartCoroutine(PlayEffect(InteractionAudioClips[clip]));
    }

    public void PlayMMMMSoundEffect() { StartCoroutine(PlayEffect(GrossDontTouch)); }

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

            //Debug.Log("Play");
            _audioSource.clip = clip;
            _audioSource.Play();

            yield return new WaitForSeconds(_audioSource.clip.length);

            _audioSource.clip = null;

        }
    }

    public void OnSceneChange(int Scene) {
        //Debug.Log("Scene Changed called by Audio manager " +  Scene);
        if (MusicMixer != null) {

            SwitchMusic(Scene);
        }
        else { Debug.Log("What the ?? " + Scene + " " ); }

        

    }

    public void SwitchMusic(int scene) {

        if (scene == 5) { // Haven start from begining
            HavenSource.Play();
        }

        StartCoroutine(FadeMusicInOut(MusicMixer, MusicMixersParamater[CurrentMixerInt] , MusicBlendDuration, 0));
        StartCoroutine(FadeMusicInOut(MusicMixer, MusicMixersParamater[scene] , MusicBlendDuration, 100));

        CurrentMixerInt = scene;
    } 

    public static IEnumerator FadeMusicInOut(AudioMixer mixer, string exposedParameter, float duration, float targetVolume ) {

       

        if (mixer == null) {
            yield break;
        }

        float currentTime = 0;
        float currentVol;

        mixer.GetFloat(exposedParameter, out currentVol);
        currentVol = Mathf.Pow(10, currentVol / 20);

        // Debug.Log("TEST " + currentVol);

        float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVol = Mathf.Lerp(currentVol, targetValue, currentTime / duration);
            
            mixer.SetFloat(exposedParameter, Mathf.Log10(newVol) * 20);
            yield return null;
        }
        yield break;
    }

}