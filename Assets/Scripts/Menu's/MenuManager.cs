using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject OptionsMenu;
    public GameObject StartMenu;

    public Menus CurrentMenuActive = Menus.MainMenu;

    public enum Menus {
        MainMenu,
        OptionsMenu,
        StartMenu
    }

    private void Awake() {
           // Make sure only the mainmenu is open.
           if (OptionsMenu.activeSelf) { OptionsMenu.SetActive(false); }
           if (StartMenu.activeSelf)   { StartMenu.SetActive(false); }
           if (!MainMenu.activeSelf)   { MainMenu.SetActive(true); }
    }
    
    public void ChangeMenu(Menus _newMenu) {
        // set current menu inactive and new active

        switch (CurrentMenuActive) {
            case Menus.MainMenu:    MainMenu.SetActive(false);    break;
            case Menus.OptionsMenu: OptionsMenu.SetActive(false); break;
            case Menus.StartMenu:   StartMenu.SetActive(false);   break;
            default: break;
        }


        switch (_newMenu) {
            case  Menus.MainMenu:   MainMenu.SetActive(true);    break;
            case  Menus.OptionsMenu:  OptionsMenu.SetActive(true); break;
            case  Menus.StartMenu:    StartMenu.SetActive(true);   break;
            default:   break;
        }

        CurrentMenuActive = _newMenu;
    }



    // Change this later. The buttons won't allow you to pass values into the function they are calling through the Onclick events, should do it via script instead ... 

    public void StartMenuFunc() { ChangeMenu(Menus.StartMenu); }
    public void OptionsMenuFunc() { ChangeMenu(Menus.OptionsMenu); }
    public void MainMenuFunc() { ChangeMenu(Menus.MainMenu); }
    public void ExitButton() { Application.Quit(); }

  
}
