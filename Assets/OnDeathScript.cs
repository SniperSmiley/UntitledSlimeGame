using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDeathScript : MonoBehaviour
{

    public GameObject DeathEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("KILL");
            Death();
        }
    }

    private void Death() {

        GameObject.Instantiate(DeathEffect, transform.position, DeathEffect.transform.rotation);
        Destroy(gameObject);
    }
}
