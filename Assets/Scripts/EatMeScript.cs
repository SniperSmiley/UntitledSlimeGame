using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatMeScript : MonoBehaviour {

    public int ChangeInSize = 2;

    private AudioSource source;
    private Transform rend;
    private CircleCollider2D col;

    private void Awake() { rend = transform.GetChild(0).transform; source = GetComponent<AudioSource>(); col = GetComponent<CircleCollider2D>(); }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Player") {

            StartCoroutine(EATFOOD());
        }
    }


    private IEnumerator EATFOOD() {

        source.Play();
        rend.gameObject.SetActive(false);
        Destroy(col);
        int calcIncrease = 6 - PlayerAnimationScript.CurrentSize;
        if (ChangeInSize >= calcIncrease) { PlayerAnimationScript.SwitchPlayerSize(PlayerAnimationScript.CurrentSize + calcIncrease); }
        else { PlayerAnimationScript.SwitchPlayerSize(PlayerAnimationScript.CurrentSize + ChangeInSize); }
       
        yield return new WaitForSeconds(source.clip.length);
        Destroy(gameObject);
    }
}
