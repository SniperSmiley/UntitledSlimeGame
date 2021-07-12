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
        Debug.Log("I EXIST");
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > 1 && Time.time - startTime < 1.5f) {
            Debug.Log("I AM ALONE");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - startTime > TimeDelayUntillPickUp)
        {
            GameObject item = collision.gameObject;

            if (collision.transform.tag == "Player") {
                // Debug.Log("Test");

                collision.gameObject.GetComponent<CharacterController2D>().ShiftSize(false);
               
                Destroy(gameObject);
            }
            
            //item.
        }
    }
}
