using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeScript : MonoBehaviour
{

    public int ChangeInSize = 2;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
            PlayerAnimationScript.SwitchPlayerSize(PlayerAnimationScript.CurrentSize + ChangeInSize);
            Destroy(gameObject);
        }
    }
   
}
