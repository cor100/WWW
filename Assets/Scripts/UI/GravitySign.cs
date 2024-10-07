using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravitySign : MonoBehaviour
{
    private RectTransform rectTransform;
    

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

    // flips sprite upside dwn depending on gravity orientation
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
