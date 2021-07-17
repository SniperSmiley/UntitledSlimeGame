using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathScript : MonoBehaviour
{
    public ParticleSystem DeathEffect;
    public ParticleSystem DeathEffectSecond;

    public PolygonCollider2D enemyCollider;

    public AudioClip[] DeathAudioClips;

    public SpriteRenderer CharacterSpriteRenderer;
    private PlayerMovement PlayerMovementScript;
    private Rigidbody2D rig;
    private SpiderScript EnemyScript;

    private ReloadScene reload;


    // Start is called before the first frame update
    void Start()
    {
        EnemyScript = GetComponent<SpiderScript>();
        PlayerMovementScript = GetComponent<PlayerMovement>();
        reload = GetComponent<ReloadScene>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            StartCoroutine(OnDeath());
        }
    }

    public IEnumerator OnDeath() {

        CharacterSpriteRenderer.enabled = false;
        PlayerMovementScript.MovementLocked = true;
        rig.constraints = RigidbodyConstraints2D.FreezePosition;

        if (DeathAudioClips.Length > 0) { Debug.Log("OUCH"); StartCoroutine(AudioManager.PlayEffect(DeathAudioClips[Random.Range(0, DeathAudioClips.Length)]));}

        Instantiate(DeathEffect, transform.position, DeathEffect.transform.rotation);
        Instantiate(DeathEffectSecond, transform.position, DeathEffect.transform.rotation);
      

        yield return new WaitForSeconds(2);

        reload.Reload();

       // Destroy(gameObject);
    }
}