using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{

    public AudioMixer AudioMixer;
    public Dropdown ResDropDown;
    public Dropdown QualityDropDown;
    public Toggle FullScreenToggle;
    public Slider MasterSlider;
    public Slider MusicSlider;
    public Slider EffectsSlider;

    private Resolution[] resolutions;
    

    private void Start() {
        float f;
        AudioMixer.GetFloat("Volume", out f); MasterSlider.value = f;
        AudioMixer.GetFloat("MusicVolume", out f); MusicSlider.value = f;
        AudioMixer.GetFloat("EffectsVolume", out f); EffectsSlider.value = f;

        FullScreenToggle.isOn = Screen.fullScreen;
        QualityDropDown.value = QualitySettings.GetQualityLevel();

        resolutions = Screen.resolutions;
        ResDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++) {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height) {
                currentResolutionIndex = i;
            }
        }

        ResDropDown.AddOptions(options);
        ResDropDown.value = currentResolutionIndex;
        ResDropDown.RefreshShownValue();
    }

    public void SetMasterVolumeReal(float volume) { AudioMixer.SetFloat("Volume", volume);  }

    public void SetMusicVolume(float volume) {AudioMixer.SetFloat("MusicVolume", volume); }

    public void SetEffectsVolume(float volume) { AudioMixer.SetFloat("EffectsVolume", volume); }
       

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullScreen) {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resIndex) {

        Resolution res = resolutions[resIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
