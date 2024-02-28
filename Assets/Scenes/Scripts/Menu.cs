using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private SpriteRenderer gravityIconRenderer;
    [SerializeField] private SpriteRenderer characterRenderer;
    public SpriteRenderer[] characters;
    public SpriteRenderer currentChar;
    void Start(){
        gravityIconRenderer = gameObject.GetComponent<SpriteRenderer>();
        currentChar = gameObject.GetComponent<SpriteRenderer>();
    }
    public void restart(){
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    public void toggleGravityIcon(){
        gravityIconRenderer.enabled = !gravityIconRenderer.enabled;
    }
    public void purple(){
        currentChar = characters[2];
    }
    public void blue(){
        currentChar = characters[1];

    }
    public void owl(){
        currentChar = characters[0];
    }

    

    
}