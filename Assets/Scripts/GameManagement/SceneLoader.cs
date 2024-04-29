using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
  [SerializeField] private string nextSceneName;

  // Quits application when clicked
  public void QuitGame()
    {
        Application.Quit();
    }
  
  public void StartGame()
    {
        PlayerPrefs.SetInt("pointsCollected", 0);
        PlayerPrefs.SetInt("currentScene", 0);
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}
