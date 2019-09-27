using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (!other.gameObject.CompareTag("Player")) return;

        gameObject.SetActive(false);
        other.gameObject.GetComponent<SquareController>().hasSecondJump = true;

    }
}
