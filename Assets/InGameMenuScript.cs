using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuScript : MonoBehaviour
{
    public static InGameMenuScript menu;

    public GameObject Menu;
    private bool active = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (menu != null ) { Destroy(this); }
        else { menu = this; }

        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (active) {  Menu.SetActive(false); }
            else {   Menu.SetActive(true);}
          
        }
        
    }


}
