using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistakeTracker : MonoBehaviour
{
    private int mistakes = 0;
    public static MistakeTracker instance = null;
    
    private void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void MistakeWasMade()
    {
        mistakes ++;
    }

    public int NumberofMistakes()
    {
        return mistakes;
    }



}
