using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class PlayerAnimationScript : MonoBehaviour {

    // Sizes : Small 0 -> x Large
    public static int[] JumpForceAtSize;
    public static float[] GravityAtSizes;
    public static float[] ColliderRadiusAtSizes;

    public static int CurrentSize = 0;  // Which Size are we???? xD
    public static int Sizes = 7;        // Number of Sizes
    public static GameObject Player;
    public static CharacterController2D Controller;
    public static Animator Anim;

    public static CircleCollider2D Col;
    public static Rigidbody2D Rig;
    public static float ColOffset;

    // public CharacterController2D Controller;
    public int StartSize = 4;

    public int[] _JumpForceAtSizes;
    public float[] _GravityAtSizes;
    public float[] _ColliderRadiusAtSizes;
    public float _collidersOffsetFromGround = 0.1f;

    public int CurrentSizeDispaly = 0;

    public AudioClip JumpCLip;
    public AudioClip[] LandingSounds;

    public Animator anim;
    public CircleCollider2D coll;
    public Rigidbody2D _rig;


    private float timeDelay = 0.2f;
    private float startTime = 0f;

    private bool inAir = false;

    private void Awake() {
        ColOffset = _collidersOffsetFromGround;
        Anim = anim;

        ColliderRadiusAtSizes = _ColliderRadiusAtSizes;
        GravityAtSizes = _GravityAtSizes;
        JumpForceAtSize = _JumpForceAtSizes;

        try {
            Player = GameObject.FindGameObjectWithTag("Player");
            Controller = Player.GetComponent<CharacterController2D>();
            Rig = Player.GetComponent<Rigidbody2D>();
            Col = transform.GetComponent<CircleCollider2D>();
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
    void Update() {
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
            if (Controller.JumpForce > 51 && Controller.m_Grounded && CurrentSize - 1 >= 0) {

                startTime = Time.time;
                anim.SetBool("isJumping", true); anim.SetBool("isGrounded", false);
                inAir = true;
                StartCoroutine(AudioManager.PlayEffect(JumpCLip));
            }
        }

        else {
            //Debug.Log(Time.time- startTime + " " + Controller.m_Grounded);
            if ((Controller.m_Grounded == true) && ((Time.time - startTime) > timeDelay) && inAir) {
                StartCoroutine(AudioManager.PlayEffect(LandingSounds[Random.Range(0, LandingSounds.Length)]));

                anim.SetBool("isJumping", false);
                anim.SetBool("isGrounded", true);

                inAir = false;
            }
        }
    }


    public static void SwitchPlayerSize(bool Shrink = true) {

        // Set new size weight to 1 Then turn the last size off
        int newSize = CurrentSize;

        if (Shrink) { if (newSize - 1 >= 0) { newSize -= 1; } }

        else { if (newSize + 1 < Sizes) { newSize += 1; } }

        AdjustSlime(newSize);
    }

    // Set new size weight to 1 Then turn the last size off
    public static void SwitchPlayerSize(int newSize) { if (newSize >= 0 && newSize < Sizes) { AdjustSlime(newSize); } }

    //  Actually makes the adjustments all in one func. ( ONly called if the cahnge is elegible )
    public static void AdjustSlime(int newSize) {

        if (CurrentSize == newSize) { return; }

        // Switch Animation Layer
        Anim.SetLayerWeight(CurrentSize, 0f);
        Anim.SetLayerWeight(newSize, 1f);

        // New jump heights
        Controller.JumpForce = JumpForceAtSize[newSize];

        // New Gravity modifier 
        if (Rig != null) { Rig.gravityScale = GravityAtSizes[newSize];}
        else { Debug.Log("NO RIG"); }

        // New collider settings
        if (Col != null) { Col.radius = ColliderRadiusAtSizes[newSize]; Col.offset = new Vector2(0, Col.radius + ColOffset); }
        else { Debug.Log("NO Col"); }
        // circleCol.radius = ColliderRadiusAtSizes[newSize];

        CurrentSize = newSize;
    }

    
}
