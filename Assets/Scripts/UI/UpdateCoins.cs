using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateCoins : MonoBehaviour
{
    private TextMeshProUGUI coinsCollected;
    // Start is called before the first frame update
    void Start()
    {
        coinsCollected = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        coinsCollected.text = GameStats.GetPointsCollected().ToString();
        
    }
}
