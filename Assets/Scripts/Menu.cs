using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject gravityIcon;

    public void restart()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    public void toggleGravityIcon()
    {
        gravityIcon.SetActive(!gravityIcon.activeSelf);
    }
}