using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWallScript : MonoBehaviour
{
    SpriteRenderer rend;
    public Color _newColor;
    Color _originalColor;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        _originalColor = rend.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.transform.tag == "Player") {
            rend.color = _newColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
            if (collision.transform.tag == "Player") {
            rend.color = _originalColor;
        }
    }
}
