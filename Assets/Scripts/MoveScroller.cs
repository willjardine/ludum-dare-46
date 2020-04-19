using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScroller : MonoBehaviour
{

    public float beatTempo = 120f;

    private bool isPlaying;
    private float speed;

    void Start()
    {
        speed = beatTempo / 60f;
    }

    void Update()
    {
        if (isPlaying)
        {
            transform.position -= new Vector3(0f, speed * Time.deltaTime, 0f);
        }
    }

    public void Play()
    {
        isPlaying = true;
    }


}
