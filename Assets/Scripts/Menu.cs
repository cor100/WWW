using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer gravityIconRenderer;
    [SerializeField] private SpriteRenderer characterRenderer;
    //public GameObject purpleMonst;
    //public GameObject blueMonst;
    // public GameObject owlMonst;
    // public GameObject startChar;

    // private Vector2 currentLocation;
    // public static GameObject currentChar;

    void Start(){
        gravityIconRenderer = gameObject.GetComponent<SpriteRenderer>();
        // if(!currentChar){
        //     currentChar = owlMonst;
        // }
    }

    void Update(){
        // currentLocation = currentChar.transform.position;
    }
    public void restart(){
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    public void toggleGravityIcon(){
        gravityIconRenderer.enabled = !gravityIconRenderer.enabled;
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