using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravitySign : MonoBehaviour
{
    private RectTransform rectTransform;
    //[SerializeField] private Image upSign;
    //[SerializeField] private Image downSign;
    //private CharGravityChecker gravityChecker;
    

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();        
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
            rectTransform.eulerAngles = new Vector3(0, 0, 180);
        }
        else
        {
            rectTransform.eulerAngles = new Vector3(0, 0, 0);
        }
    }


}
