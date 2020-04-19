﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (LevelManager.instance.isPlaying && LevelManager.instance.canMove && LevelManager.instance.isGameOver == false)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                LevelManager.instance.WaitForNextMove();
                spriteRenderer.sprite = pressedImage;
            }
        }
        if (Input.GetKeyUp(keyToPress))
        {
            spriteRenderer.sprite = defaultImage;
        }
    }

}