using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript manager;

    public delegate void OnSceneChangeEvent();
    public static event OnSceneChangeEvent SceneChanged;

    public enum Scenes{
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
    }


    public void SwitchScene(int SceneToSwitchTo) {
        SceneManager.LoadScene(SceneToSwitchTo);
        SceneChanged();
    }


    // CUrrently a very cheaty method. All below should be squished into one function.

    public void StartGame() {
        SceneManager.LoadScene(1);
        SceneSwitch();
    } 

    public void LevelTwo() {
        SceneManager.LoadScene(2);
        SceneSwitch();
    }

    public  void ExitToMenu() {
        SceneManager.LoadScene(0);
        SceneSwitch();
    }

    private void SceneSwitch() {
        SceneChanged();
    }
}
