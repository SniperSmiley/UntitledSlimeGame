using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelScript : MonoBehaviour
{
    public GameObject World;
    public GameObject TunnelFg;

    bool ShowingWorld = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {

            if (ShowingWorld) {
                World.SetActive(false);
                TunnelFg.SetActive(false);
                ShowingWorld = false;
            }
            else {
                World.SetActive(true);
                TunnelFg.SetActive(true);
                ShowingWorld = true;
            }

        }
    }
}
