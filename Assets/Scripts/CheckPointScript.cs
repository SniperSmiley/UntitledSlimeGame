using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    public Transform SpawnLocation;
    public int SpawnSize;

    private void Awake() {
       
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {
            GameManagerScript.SpawnPos = SpawnLocation.position;
            GameManagerScript.SpawnSize = SpawnSize;
        }
    }



}
