using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMultiplier : MonoBehaviour
{

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Multiplier: x" + LevelManager.instance.currentMultiplier;

        if (LevelManager.instance.isGameOver)
        {
            gameObject.SetActive(false);
        }
    }

}
