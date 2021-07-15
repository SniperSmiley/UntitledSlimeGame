using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
   public void StartGame() {
        SceneManager.LoadScene(1); 
    } 

    public void LevelTwo() {
        SceneManager.LoadScene(2);
    }

    public static void ExitToMeu() {
        SceneManager.LoadScene(0);
    }
}
