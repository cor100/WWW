using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesTutorialManager : MonoBehaviour
{
    public GameObject menu;


    ////// Update is called once per frame
    //void Update()
    //{
    //    if (isNotTouching)
    //    {
    //        menu.SetActive(!menu.activeSelf);
    //    }
    //}

    ////public void menuSetActive()
    ////{
    ////    if(Input.GetKeyDown(KeyCode.RightShift))
    ////    {
    ////        menu.SetActive(!menu.activeSelf);
    ////    } 
    ////}

    ////public CharacterAnimator characterAnimator;
    //////private float deathAnimationTime = 1;
    //////private bool isDead = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            menu.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            menu.SetActive(false);
        }
    }
}
