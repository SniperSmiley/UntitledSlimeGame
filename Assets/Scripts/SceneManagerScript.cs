using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public static SceneManagerScript manager;

    public delegate void OnSceneChangeEvent(int Scene);
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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.L)) {
            SwitchScene((int) GameManagerScript.manager.CurScene + 1);
        }
    }


    public void SwitchScene(int SceneToSwitchTo) {
        SceneManager.LoadScene(SceneToSwitchTo);
        SceneChanged(SceneToSwitchTo);
    }


    // CUrrently a very cheaty method. All below should be squished into one function.

    
}
