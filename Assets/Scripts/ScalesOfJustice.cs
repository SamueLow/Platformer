using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesOfJustice : MonoBehaviour
{
    private Vector3 startingHighPosition, startingLowPosition;
    public GameObject pairedPlatform;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        startingHighPosition = IsHigherPlatform() ? transform.position : pairedPlatform.transform.position;
        startingLowPosition = !IsHigherPlatform() ? transform.position : pairedPlatform.transform.position;
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            if (transform.position.y > startingLowPosition.y) {
                transform.position = new Vector2(transform.position.x, transform.position.y - speed);   
                pairedPlatform.transform.position = new Vector2(pairedPlatform.transform.position.x, pairedPlatform.transform.position.y + speed);
                other.gameObject.transform.position = new Vector2(other.gameObject.transform.position.x, other.gameObject.transform.position.y - speed);   
            }
        }
    }

    private bool IsHigherPlatform() {
        return transform.position.y > pairedPlatform.transform.position.y;
    }
}
