using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript manager;

    private void Awake() {
        if (manager != null) { Destroy(this); }
        else { manager = this; }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
