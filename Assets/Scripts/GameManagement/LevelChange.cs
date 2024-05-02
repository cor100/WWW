using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    private string firstLevel = "Level 1";
    private string lastScene = "Level 3";
    // Will be an onTrigger collision
    private void OnTriggerEnter2D(Collider2D doorCollision)
    {
        // If the door is activated by the player going in, switch scenes. 
        // If current scene is last scene, skip directly to victory scene
        // if(doorCollision.CompareTag("player") && SceneManager.GetActiveScene().name == lastScene){
        //     print(SceneManager.GetActiveScene().name == lastScene);
        //     SceneManager.LoadScene("End", LoadSceneMode.Single);
        // }
        // // If current scene is Tutorial, skip directly to first level without point allocation
        // if (doorCollision.CompareTag("player") && SceneManager.GetActiveScene().name != "Tutorial")
        // {
        //     PlayerPrefs.SetInt("pointsCollected", PointStats.GetPointsCollected());
        //     SceneManager.LoadScene("AllocatePoints", LoadSceneMode.Single);
        // } else if(doorCollision.CompareTag("player")){
        //     SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
        // }

        if(doorCollision.CompareTag("player")){
            if(SceneManager.GetActiveScene().name == lastScene){
                print("end");
                SceneManager.LoadScene("End", LoadSceneMode.Single);
            }else if(SceneManager.GetActiveScene().name == "Tutorial"){
                SceneManager.LoadScene(firstLevel, LoadSceneMode.Single);
            }else{
                PlayerPrefs.SetInt("pointsCollected", PointStats.GetPointsCollected());
                SceneManager.LoadScene("AllocatePoints", LoadSceneMode.Single);
            }
        }
    }

}
