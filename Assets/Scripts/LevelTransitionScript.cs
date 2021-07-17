using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTransitionScript : MonoBehaviour
{
    public int LevelToSwitchTo = 2;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            SceneManagerScript.manager.SwitchScene(LevelToSwitchTo);
        }
    }
}
