using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundChange : MonoBehaviour
{
    [SerializeField] public GameObject background;
    private BackgroundChange backgroundChange;
    private Color redBackground = new(146f/255f, 10f/255f, 8f/255f);

    // responsibility of class: changes camera background to red when background changes to red

    // Start is called before the first frame update
    void Start()
    {
        backgroundChange = background.GetComponent<BackgroundChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (backgroundChange.returnRedBackgroundStatus())
        {
            gameObject.GetComponent<Camera>().backgroundColor = redBackground;
        }
    }
}
