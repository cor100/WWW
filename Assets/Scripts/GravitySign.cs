using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravitySign : MonoBehaviour
{
    private Image imageRenderer;
    [SerializeField] private Image upSign;
    [SerializeField] private Image downSign;
    //private CharGravityChecker gravityChecker;
    

    // Start is called before the first frame update
    void Start()
    {
        imageRenderer = GetComponent<Image>();
        imageRenderer = downSign;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        if(CharGravityChecker.Get().returnGravityDown())
        {
            imageRenderer = downSign;
        }
        else
        {
            imageRenderer = upSign;
        }
    }


}
