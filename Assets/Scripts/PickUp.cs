using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    public float TimeDelayUntillPickUp = .5f;

    private float startTime;

    private bool isColliding = false;
    private GameObject Coll;

    private void Awake() {
        startTime = Time.time;
    }

    private void Update() {
        if (!isColliding) { return; }

        if (Time.time - startTime > TimeDelayUntillPickUp) {

            PlayerAnimationScript.SwitchPlayerSize(false);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) { if (collision.transform.tag == "Player") { Coll = collision.gameObject; isColliding = true; } }
        
  

    private void OnCollisionExit2D(Collision2D collision) { if (collision.transform.tag == "Player") { isColliding = false; } }

}
