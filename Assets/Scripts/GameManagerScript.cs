using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript manager;
    public Scenes CurScene = 0;

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

        SceneManagerScript.SceneChanged += OnSceneChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneChange(int Scene) {
       // Debug.Log("Scene Changed called by Game manager");
        CurScene = (Scenes)Scene;



    }
}