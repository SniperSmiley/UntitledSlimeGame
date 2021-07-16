using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript manager;

    private void Awake() {
        if (manager != null) { Destroy(this); }
        else { manager = this; }

        SceneManagerScript.SceneChanged += OnSceneChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneChange() {
        Debug.Log("Scene Changed called by Game manager");


    }
}
