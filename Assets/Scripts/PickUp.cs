using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour {
    public float TimeDelayUntillPickUp = 0.7f;

    private float startTime;

    private bool isColliding = false;
    private GameObject col;

    // Start is called before the first frame update
    void Start() {

    }

    private void Awake() {
        startTime = Time.time;
    }

    private void Update() {


        if (!isColliding) { return; }

        if (Time.time - startTime > TimeDelayUntillPickUp) {

            if (col.transform.tag == "Player") {
                // Debug.Log("Test");

                PlayerAnimationScript.SwitchPlayerSize(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) { col = collision.gameObject; isColliding = true; }

    private void OnCollisionExit2D(Collision2D collision) {  isColliding = false; }


}
