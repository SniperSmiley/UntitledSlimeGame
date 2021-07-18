using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Checkpoints etc
    public static Vector2 SpawnPos;
    public static int SpawnSize;

    public static GameManagerScript manager;
    public Scenes CurScene = 0;

    private GameObject Player;

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

        if ((Scenes) Scene == CurScene) {

            if (Scene == (int)Scenes.StartMenu || Scene == (int)Scenes.Level5) {

            }
            else {
                       // Scene reloaded
               // Player = GameObject.FindGameObjectWithTag("Player");
             //   Player.transform.position = SpawnPos;
               // PlayerAnimationScript.SwitchPlayerSize(SpawnSize);
            }
         
        }
        else {
              // Make sure it is not credits or main menu
              if (Scene == (int) Scenes.StartMenu || Scene == (int)Scenes.Level5) {

                }
            else {
                //ResetPlayerPosSize();
            }

        }

       // Debug.Log("Scene Changed called by Game manager");
        CurScene = (Scenes)Scene;



    }


    private void ResetPlayerPosSize() {

        Player = GameObject.Find("Slime");
        SpawnPos = Player.transform.position;
        SpawnSize = PlayerAnimationScript.CurrentSize;

    }
}