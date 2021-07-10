using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class DragMeScript : MonoBehaviour {

    public float DragForce = 1f;

    private Vector3 startPos;
    private Vector3 mousePos;

    private Rigidbody2D rig;


    private void Awake() { rig = transform.GetComponent<Rigidbody2D>(); }

    private void OnMouseDown() {

        if (Input.GetMouseButtonDown(0)) {

            rig.velocity = Vector3.zero;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPos = new Vector3(mousePos.x, mousePos.y, 0);
        }
    }

    private void OnMouseUp() {

        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        // Distance pulled away is the force
        Vector2 direction = (startPos - mousePos).normalized;
        float distance = (startPos - mousePos).magnitude;
        float force = distance * DragForce;

        rig.AddForce(-direction * force, ForceMode2D.Impulse);
    }
}
