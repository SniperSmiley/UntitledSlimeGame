using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomOnClick : MonoBehaviour
{
    private AudioManager audioManager;

    public Button CustomButton;
    public int Mode = 0;
    private int numClicks = 0;

    [Header("0 : If switching scene")]
    [Tooltip("0: MainMenu 1: Options 2: Start ")]
    public MenuManager MenuManager;
    public int MenuToSwitchTo;

    [Header("1 : If Exit")]
    public string Ignore;

    [Header("2 : Just play sound effect")]
    public string Ignore2;
        
    private void Awake() {
        CustomButton.onClick.AddListener(CustomButtonOnClick);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void CustomButtonOnClick() {
        audioManager.PlaySquelchSoundEffect();

        switch (Mode) {

            case 0: MenuManager.ChangeMenu((MenuManager.Menus) MenuToSwitchTo); break; // change menu
            case 1: Application.Quit(); break; // exit game
            case 2: break; // nothing
            case 3: numClicks++; 
                if (numClicks >= 5) { audioManager.PlayMMMMSoundEffect(); numClicks = 0; }
                
                break;

            default:
                break;
        }
    }



}
