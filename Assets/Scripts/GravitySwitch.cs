using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    private Vector3 startingGravity;

    void Start()
    {
        startingGravity = Physics2D.gravity;
    }

 
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            SwitchGravity();
        }
    }
    public void SwitchGravity()
    {
        Physics2D.gravity = -Physics2D.gravity;
        Camera.main.transform.RotateAround(Camera.main.transform.position, Camera.main.transform.forward, 180);
        SquareController squareController = GameObject.FindObjectOfType<SquareController>();
        squareController.normalGravity = !squareController.normalGravity;
    }

    private void OnDestroy() {
        Physics2D.gravity = startingGravity;
    }
}
