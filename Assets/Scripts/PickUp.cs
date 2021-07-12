using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float TimeDelayUntillPickUp = 3f;

    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake() {
        startTime = Time.time;
    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - startTime > TimeDelayUntillPickUp)
        {
            GameObject item = collision.gameObject;

            if (collision.transform.tag == "Player") {
                // Debug.Log("Test");

                PlayerAnimationScript.SwitchPlayerSize(false);
                Destroy(gameObject);
            }
            
            //item.
        }
    }
}
