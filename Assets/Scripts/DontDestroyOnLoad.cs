using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static GameObject Handlers;

    private void Awake() {
        if (Handlers != null) { Destroy(gameObject); }

        else {
            Handlers = gameObject;
            DontDestroyOnLoad(gameObject);
        }

    }
}
