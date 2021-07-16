using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuScript : MonoBehaviour
{
    public static InGameMenuScript menu;

    public GameObject Menu;
    public Canvas Canvas;

    private Canvas canvas;
    private bool active = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (menu != null ) { Destroy(this); }
        else { menu = this; }

        Menu.SetActive(false);

        SceneManagerScript.SceneChanged += OnSceneChange;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){

            if (active) { DisableMenu();  }
            else { EnableMenu();  }
          
        }
        
    }

    private void OnSceneChange() {
      //  Canvas.worldCamera = Camera.main;
        Debug.Log("Scene Change event called from MENU");

        if (Menu == null) { return; } 

        if (active) {
            DisableMenu();
        }
    
    }

    private void DisableMenu() { Menu.SetActive(false); active = false; Time.timeScale = 1; }
       
    private void EnableMenu() {  Menu.SetActive(true); active = true; Time.timeScale = 0;  }

   





}
