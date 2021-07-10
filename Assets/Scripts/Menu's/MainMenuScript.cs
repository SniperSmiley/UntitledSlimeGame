using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
   // DELETE AT SOME POINT TRASH

    public GameObject TitleGo;

    private bool firstClick = true;



    public void OnTitleClicked() {

        if (firstClick) {
            TitleGo.GetComponent<Animator>().enabled = false;

            firstClick = false;
        }

    }
}
