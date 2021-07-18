using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlugSwitch : MonoBehaviour {

    public Animator anim;
    public bool Trigger = false;
    private SpriteRenderer[] rends;

    public Color OffColour;
    public Color OnColour;

    private void Awake() {
        rends = GetComponentsInChildren<SpriteRenderer>();
    }



    private void OnTriggerEnter2D(Collider2D collision) {
         Debug.Log("COL" + collision.transform.name);
        if (collision.transform.tag == "Battery") {
            Trigger = true;   Debug.Log("COL1" + collision.transform.name);
            foreach (SpriteRenderer rend in rends) {
                rend.color = OnColour;
            }
            anim.SetBool("ShouldAnimate", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
         if (collision.transform.tag == "Battery") {
            Trigger = false;
            foreach (SpriteRenderer rend in rends) {
                rend.color = OffColour;
            }
            anim.SetBool("ShouldAnimate", false);
        }
    }

}
