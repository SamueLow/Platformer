using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    private int jumpCounter = 0;
    public int maxJumps = 3;
    public TextMeshPro jumpDisplay;
    private int currentScene = 0;

    private void Start() {
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SkipLevel();
        }
        jumpDisplay.text = "Jumps: " + (maxJumps - jumpCounter) + "/" + (maxJumps);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(currentScene + 1);
        }
    } 

    public void IncrementJumpCounter()
    {
        jumpCounter +=1;

        if (jumpCounter > maxJumps)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
        MistakeTracker.instance.MistakeWasMade();
    }

    public void SkipLevel()
    {
        SceneManager.LoadScene(currentScene + 1);
    }
}
