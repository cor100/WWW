using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject gravityIcon;
    
    void Start(){
    }

    void Update(){
    }
    public void restart(){
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    public void toggleGravityIcon(){
        gravityIcon.SetActive(!gravityIcon.activeSelf);
    }
    // public void purple(){
    //     blueMonst.SetActive(false);
    //     owlMonst.SetActive(false);
    //     purpleMonst.transform.position = currentLocation;
    //     purpleMonst.SetActive(true);
    //     currentChar = purpleMonst;
    // }
    // public void blue(){
    //     blueMonst.SetActive(true);
    //     blueMonst.transform.position = currentLocation;
    //     owlMonst.SetActive(false);
    //     purpleMonst.SetActive(false);
    //     currentChar = blueMonst;
    // }
    // public void owl(){
    //     blueMonst.SetActive(false);
    //     owlMonst.SetActive(true);
    //     owlMonst.transform.position = currentLocation;
    //     purpleMonst.SetActive(false);
    //     currentChar = owlMonst;
    // }

    

    
}