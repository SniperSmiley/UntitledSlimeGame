using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAnimationScript : MonoBehaviour
{
    
    // Sizes : Small 0 -> x Large

    public static int CurrentSize = 0;  // Which Size are we???? xD
    public static int Sizes = 2;        // Number of Sizes
    public static GameObject Player;
    public static CharacterController2D Controller;
  

   // public CharacterController2D Controller;
    public Animator anim;

    private float timeDelay = 0.2f;
    private float startTime = 0f;

    private bool inAir = false;

    private void Awake() {
        try {
            Player = GameObject.FindGameObjectWithTag("Player");
            Controller = Player.GetComponent<CharacterController2D>();
        }
        catch (System.Exception) {
            Debug.LogError("ERROR : PLAYERANIMATIONSCRIPT - COULD NOT FIND PLAYER OR CONTROLLER");
            throw;
        }
 

    }

    // Update is called once per frame
    void Update()
    {
        // if they successfully jump play start jump animation 
        // Jump is pressed, grounded and force in more than 50
        if (Input.GetButtonDown("Jump")) {
             //Debug.Log("JUMP");
            if (Controller.JumpForce > 51 && Controller.m_Grounded) {
               
                startTime = Time.time;
                anim.SetBool("isJumping", true); anim.SetBool("isGrounded", false);
                inAir = true;
            }
        }

        else {
            //Debug.Log(Time.time- startTime + " " + Controller.m_Grounded);
            if ((Controller.m_Grounded == true) && ( ( Time.time - startTime ) > timeDelay) && inAir)
            {  
                anim.SetBool("isJumping", false); 
                anim.SetBool("isGrounded", true);

                inAir = false;
            }
        }
    }


    public static void SwitchPlayerSize(bool Shrink = true) {

        if (Shrink) {

        }

        else {


        }


    }
}
