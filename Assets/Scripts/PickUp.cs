using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time - startTime > 3f)
        {
            GameObject item = collision.gameObject;
            //item.
        }
    }
}
