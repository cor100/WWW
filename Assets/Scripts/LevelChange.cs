using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{

    public int sceneIndex;

    // Will be an onTrigger collision
    private void OnTriggerEnter2D(Collider2D doorCollision)
    {
        // If the door is activated by the player going in, switch scenes.
        if (doorCollision.CompareTag("player"))
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }

    }

}
