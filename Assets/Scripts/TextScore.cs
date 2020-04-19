using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour
{

    private Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        text.text = "Score: " + LevelManager.instance.score;

        if (LevelManager.instance.isGameOver)
        {
            gameObject.SetActive(false);
        }
    }

}
