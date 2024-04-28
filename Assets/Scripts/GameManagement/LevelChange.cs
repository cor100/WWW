using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    private string firstLevel = "E_Level2";
    private string lastscene = "Victory Scene 1";

    // Will be an onTrigger collision
    private void OnTriggerEnter2D(Collider2D doorCollision)
    {
        // If the door is activated by the player going in, switch scenes. 
        // If current scene is Tutorial, skip directly to first level without point allocation
        // If the current scene is 
        if (doorCollision.CompareTag("player")){
            if(SceneManager.GetActiveScene().name == "Tutorial"){
                SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
            }
            if(SceneManager.GetActiveScene().name != "AldoScene2"){
                SceneManager.LoadScene(lastscene, LoadSceneMode.Single);
            }
            else{
                PlayerPrefs.SetInt("pointsCollected", PointStats.GetPointsCollected());
                SceneManager.LoadScene("AllocatePoints", LoadSceneMode.Single);
            }
        } 
    }

}
