using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour {

    public AudioSource source;

    public GameObject player;

    public Transform pos1;
    public Transform pos2;

    public Transform RayFirePoint;

    public float minDistFromFlag = 0.15f;

    public float RunSpeed = 10f;
    public float NormalSpeed = 5f;

    public float AttackDist = 0.5f;

    public float ForgetPlayerTime = 0.6f;

    public float SightForward = 5f;
    public LayerMask Mask;

    private Vector2 curTarget;
    private float timeLostPlayer = 0f;
    private bool target = false; // default is pos 2
    public bool isChasingPlayer = false;

    private float dist;
    private Vector2 lookDirection;

    private bool colourRed = false;
    private SpriteRenderer rend;

    private bool LostPlayer = false;
    public bool attacking = false;

    public bool PlayAttackAnim = false;
    private Animator anim;

    RaycastHit2D ray;

    private bool attackRoutineRUnning = false;

    public bool Nope = false;

    public bool disable = false;

    // Start is called before the first frame update
    void Start() {
        rend = gameObject.GetComponent<SpriteRenderer>();
        curTarget = pos2.position;
        lookDirection = -transform.right;
        anim = GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update() {
            
        if (disable) { return; }

        //   if (PlayAttackAnim) { anim.SetBool("Attack", false); } 

        // Feeeling very out of it today.. sorrry for bad code xD

        dist = transform.position.x - curTarget.x;

        if (!Nope) { FireRayAtPlayer(); }
   

        if (Mathf.Abs(dist) < minDistFromFlag && !isChasingPlayer) {
            // Switch targets
            if (target) { curTarget = pos2.position; target = false; } // Debug.Log("Pos2"); }
            else if (!target) { curTarget = pos1.position; target = true; } //Debug.Log("Pos1"); }
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
        
         //st = transform.position.x - curTarget.position.x;
        // Maybe attack?
        if ( isChasingPlayer) {
            if (ray.collider.gameObject.tag == "Player") {
             if ((ray.collider.gameObject.transform.position - transform.position ).magnitude < AttackDist) {
                    if (!attackRoutineRUnning) { StartCoroutine(TryAttack()); attacking = true; attackRoutineRUnning = true; }
                    
            }
        }
        }


        MoveSpider();
    }

    public IEnumerator TryAttack() {
        source.Play();
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(.20f);
        if (ray.collider != null) {
             if (ray.collider.tag == "Player") {
             if ((ray.collider.gameObject.transform.position - transform.position ).magnitude < AttackDist) {
                Attack(ray.collider.gameObject);
                    
            }
        }
        }
      
        anim.SetBool("Attack", false); ;
        attacking = false;
        attackRoutineRUnning = false;      
    }

    public void Attack(GameObject player) {

            if (PlayAttackAnim) { anim.SetBool("Attack", true); }
            Nope = true; isChasingPlayer = false;
            StartCoroutine(player.GetComponentInParent<OnDeathScript>().OnDeath());

        
    }

    private void FireRayAtPlayer() {
        // Check if can see player.
        ray = Physics2D.Raycast(RayFirePoint.position, lookDirection, SightForward, Mask);


        if (ray.collider != null) {
            //Debug.Log("HIt" + ray.collider.name);
            Debug.DrawRay(RayFirePoint.position, lookDirection * ray.distance, Color.red, .1f);

            // check if player
            if (ray.collider.tag == "Player") { curTarget = ray.collider.transform.position; isChasingPlayer = true; LostPlayer = false; }

            else {
                if (isChasingPlayer)
                { 
                    if (LostPlayer) {
                        if ( Time.time - timeLostPlayer > ForgetPlayerTime) {
                             isChasingPlayer = false; curTarget = pos2.position;
                            LostPlayer = false;
                        }
                    }
                    else {
                        LostPlayer = true;
                        timeLostPlayer = Time.time;
                    }

                   
                } 
            }
        }

        else { Debug.DrawRay(RayFirePoint.position, lookDirection * SightForward, Color.red, .1f); if (isChasingPlayer) { isChasingPlayer = false; curTarget = pos2.position; } }

        /*
        if (ray2.collider != null) {
            Debug.DrawRay(RayFirePoint.position, new Vector2(lookDirection.x, 0.7f) *  ray2.distance, Color.red, .1f);
            // check if player
            if (ray.collider.tag == "Player") { curTarget = ray.collider.transform; isChasingPlayer = true; }
            else { if (isChasingPlayer) { isChasingPlayer = false; curTarget = pos2; } }
        }
        else { Debug.DrawRay(RayFirePoint.position, new Vector2(lookDirection.x, 0.7f) *  SightForward, Color.red, .1f); if (isChasingPlayer) { isChasingPlayer = false; curTarget = pos2; } }*/
    }

    private void MoveSpider() {

        if (attacking) { return; }

        // Rotation
        if (dist > 0.1f) { if (transform.localScale.x < 0) { flip(); } }

        else { if (transform.localScale.x > 0) { flip(); } }

        // What is the distance to travel this frame?
        float step;
        if (isChasingPlayer) { step = RunSpeed * Time.deltaTime; }
        else {step = NormalSpeed * Time.deltaTime; }
 
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(curTarget.x,transform.position.y, transform.position.z), step);

    }

    private void flip() {

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        if (scale.x > 0) { lookDirection = -transform.right; }
        else { lookDirection = transform.right; }

    }

    

}
