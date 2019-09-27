using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResizer : MonoBehaviour
{
    private void Awake() 
    {
        Screen.SetResolution(500, 500, false, 60);
    }
}
