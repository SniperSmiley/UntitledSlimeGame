using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour {

    public Transform pos1;
    public Transform pos2;
    public Transform RayFirePoint;

    public float minDistFromFlag = 0.15f;

    public float RunSpeed = 10f;
    public float NormalSpeed = 5f;

    public float SightForward = 5f;
    public LayerMask Mask;

    private Transform curTarget;
    private float timeStarted = 0f;
    private bool target = false; // default is pos 2
    private bool isChasingPlayer = false;

    private float dist;
    private Vector2 lookDirection;

    private bool colourRed = false;
    private SpriteRenderer rend;


    // Start is called before the first frame update
    void Start() {
        rend = gameObject.GetComponent<SpriteRenderer>();
        curTarget = pos2;
        lookDirection = -transform.right;
    }

    // Update is called once per frame
    void Update() {

        dist = transform.position.x - curTarget.position.x;

        // Check if can see player.
        RaycastHit2D ray = Physics2D.Raycast(RayFirePoint.position, lookDirection, SightForward, Mask); ;

        if (ray.collider != null) {
            //Debug.Log("HIt" + ray.collider.name);
            Debug.DrawRay(RayFirePoint.position, lookDirection * ray.distance, Color.red, .1f);

            // check if player
            if (ray.collider.tag == "Player") { curTarget = ray.collider.transform; isChasingPlayer = true; }
            else { if (isChasingPlayer) { isChasingPlayer = false; curTarget = pos2;  } }
        }
        else { Debug.DrawRay(RayFirePoint.position, lookDirection * SightForward, Color.red, .1f);  if (isChasingPlayer) { isChasingPlayer = false; curTarget = pos2; } }

        if (Mathf.Abs(dist) < minDistFromFlag && !isChasingPlayer) {
            // Switch targets
            if (target) { curTarget = pos2; target = false; } // Debug.Log("Pos2"); }
            else if (!target) { curTarget = pos1; target = true; } //Debug.Log("Pos1"); }
        }


        // Change colour
        if (isChasingPlayer) {
            if (!colourRed) {
                rend.color = new Color(255, 0, 0);
                colourRed = true;
            }
        }
        else {
            if (colourRed) {
                rend.color = new Color(255, 255, 255);
                colourRed = false;
            }
        }

        MoveSpider();
    }

    private void MoveSpider() {

        // Rotation
        if (dist > 0.1f) { if (transform.localScale.x < 0) { flip(); } }

        else { if (transform.localScale.x > 0) { flip(); } }

        // What is the distance to travel this frame?
        float step;
        if (isChasingPlayer) { step = RunSpeed * Time.deltaTime; }
        else {step = NormalSpeed * Time.deltaTime; }
 
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(curTarget.position.x,transform.position.y, transform.position.z), step);

    }

    private void flip() {

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        if (scale.x > 0) { lookDirection = -transform.right; }
        else { lookDirection = transform.right; }

    }

}
