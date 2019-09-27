using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MistakeCounterController : MonoBehaviour
{
    public TextMeshProUGUI counter;
    void Start()
    {
        counter.text = "Mistakes:" + MistakeTracker.instance.NumberofMistakes();
    }

}
