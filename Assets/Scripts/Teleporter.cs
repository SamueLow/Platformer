using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportTo;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
           other.gameObject.transform.position = teleportTo.transform.position;
        
            teleportTo.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
