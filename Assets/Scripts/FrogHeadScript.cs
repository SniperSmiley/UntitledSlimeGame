using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogHeadScript : MonoBehaviour
{
    public GameObject Frog;
    public GameObject FrogDeathParticle;
    public SpriteRenderer rend;
    public FrogScript _frog;
    public AudioClip Clip;

    bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {

            if (collision.transform.position.y > transform.position.y) {
                return;
            }

            if (triggered) { return;  }
            triggered = true;
            _frog.disable = true;
            StartCoroutine(killFrog());
        }
    }

    private IEnumerator killFrog() {

        StartCoroutine(AudioManager.PlayEffect(Clip));
        rend.enabled = false;
        GameObject frogDeath = Instantiate(FrogDeathParticle, transform.position, FrogDeathParticle.transform.rotation);
        yield return new WaitForSeconds(frogDeath.GetComponent<ParticleSystem>().main.duration);
        GameObject.Destroy(Frog);
        yield break;
    }
}
