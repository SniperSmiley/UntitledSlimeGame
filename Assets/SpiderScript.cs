using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderScript : MonoBehaviour {

    public Transform pos1;
    public Transform pos2;

    public float minDistFromFlag = 0.15f;

    public float RunSpeed = 10f;
    public float NormalSpeed = 5f;

    private Transform curTarget;
    private float timeStarted = 0f;
    private bool target = false; // default is pos 2

    private float dist;

    // Start is called before the first frame update
    void Start() {
        curTarget = pos2;
    }

    // Update is called once per frame
    void Update() {

        dist = transform.position.x - curTarget.position.x;
        if (Mathf.Abs(dist) < minDistFromFlag) {

            // Switch targets
            if (target) { curTarget = pos2; target = false; Debug.Log("Pos2"); }
            else if (!target) { curTarget = pos1; target = true; Debug.Log("Pos1"); }

        }

        MoveSpider();
    }

    private void MoveSpider() {

        // Rotation
        if (dist > 0.1f) { if (transform.localScale.x < 0) { flip(); } }

        else { if (transform.localScale.x > 0) { flip(); } }

        // What is the distance to travel this frame?
        float step = NormalSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, curTarget.position, step);

    }

    private void flip() {

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    
    }

}
