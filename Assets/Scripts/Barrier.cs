using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("player")){
            Invoke("ReloadScene", 1);
        }
    }
    void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}