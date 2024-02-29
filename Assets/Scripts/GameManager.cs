using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("player");
        // Make the GameObject persist across scene changes
        if(player){
            player.GetComponent<CharacterJump>().enabled = false;
            player.GetComponent<CharHorizontalMovement>().enabled = false;
            player.gameObject.GetComponent<CharacterAnimator>().onPlayerDied(false);

            DontDestroyOnLoad(player);
        }
    }
}
