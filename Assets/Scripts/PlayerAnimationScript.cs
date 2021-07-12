using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAnimationScript : MonoBehaviour
{
    
    // Sizes : Small 0 -> x Large
    public static int[] JumpForceAtSize;
    public static int CurrentSize = 0;  // Which Size are we???? xD
    public static int Sizes = 7;        // Number of Sizes
    public static GameObject Player;
    public static CharacterController2D Controller;
    public static Animator Anim;

    // public CharacterController2D Controller;
    public int StartSize = 4;
    public int[] _JumpForceAtSizes;
    public int CurrentSizeDispaly = 0;

    public AudioClip JumpCLip;
    public AudioClip[] LandingSounds;

    public Animator anim;


    private float timeDelay = 0.2f;
    private float startTime = 0f;

    private bool inAir = false;

    private void Awake() {

        Anim = anim;
        JumpForceAtSize = _JumpForceAtSizes;

        try {
            Player = GameObject.FindGameObjectWithTag("Player");
            Controller = Player.GetComponent<CharacterController2D>();
        }
        catch (System.Exception) {
            Debug.LogError("ERROR : PLAYERANIMATIONSCRIPT - COULD NOT FIND PLAYER OR CONTROLLER");
            throw;
        }
 

    }

    private void Start() {
        SwitchPlayerSize(StartSize);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentSizeDispaly = CurrentSize;
        // TEST

        if (Input.GetKeyDown(KeyCode.Y)) {
            SwitchPlayerSize(false);
        }

        else if (Input.GetKeyDown(KeyCode.H)) {
             SwitchPlayerSize();
        }

        // if they successfully jump play start jump animation 
        // Jump is pressed, grounded and force in more than 50
        if (Input.GetButtonDown("Jump")) {
             //Debug.Log("JUMP");
            if (Controller.JumpForce > 51 && Controller.m_Grounded) {
                
                startTime = Time.time;
                anim.SetBool("isJumping", true); anim.SetBool("isGrounded", false);
                inAir = true;
                StartCoroutine(AudioManager.PlayEffect(JumpCLip));
            }
        }

        else {
            //Debug.Log(Time.time- startTime + " " + Controller.m_Grounded);
            if ((Controller.m_Grounded == true) && ( ( Time.time - startTime ) > timeDelay) && inAir)
            {
                StartCoroutine(AudioManager.PlayEffect(LandingSounds[Random.Range(0, LandingSounds.Length)]));

                anim.SetBool("isJumping", false); 
                anim.SetBool("isGrounded", true);

                inAir = false;
            }
        }
    }


    public static void SwitchPlayerSize(bool Shrink = true) {

        // Set new size weight to 1 Then turn the last size off

        int newSize= CurrentSize;

        if (Shrink) {
            if (newSize - 1 >= 0) {
                   newSize -= 1;
            }
         
        }

        else {
            if (newSize + 1 < Sizes) {
                   newSize += 1;
            }

        }

        Anim.SetLayerWeight(CurrentSize, 0f);
        Anim.SetLayerWeight(newSize, 1f);

        // Set new jump height;
        Controller.JumpForce = JumpForceAtSize[newSize];

        CurrentSize = newSize;


    }

    public static void SwitchPlayerSize(int newSize) {

        // Set new size weight to 1 Then turn the last size off

        if (newSize >= 0 && newSize < Sizes) {
            
            Anim.SetLayerWeight(CurrentSize, 0f);
            Anim.SetLayerWeight(newSize, 1f);

            // New jump heights
            Controller.JumpForce = JumpForceAtSize[newSize];

            CurrentSize = newSize;

        }


    }
}
