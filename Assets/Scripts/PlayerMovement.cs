using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {


    public CharacterController2D controller;

    // Start is called before the first frame update
    void Start() {

    }

    public float runSpeed = 40f;
    public float horizontalMove = 0f;
    bool jump = false;

    public bool MovementLocked = false;

    // Update is called once per frame
    void Update() {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }

   
    }

    void FixedUpdate() {

        if (MovementLocked) { return; }

        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
   
    }

}
