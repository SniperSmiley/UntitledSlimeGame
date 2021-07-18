using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotTouchScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {
           // Debug.Log("FECK");
            StartCoroutine(collision.transform.GetComponentInParent<OnDeathScript>().OnDeath());
        }
    }

}
