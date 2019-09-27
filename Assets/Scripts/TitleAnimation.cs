using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
    bool movingUp = false;
    public float speed = .1f;
    public float distanceFromOG = 5f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

 
    void Update()
    {
        if (transform.position.y > (originalPosition.y + distanceFromOG))
        {
            movingUp = false;

        }

        if (transform.position.y < (originalPosition.y - distanceFromOG))
        {
            movingUp = true;
        }

        if (movingUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z); 
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z); 
        }
        
    }
}
