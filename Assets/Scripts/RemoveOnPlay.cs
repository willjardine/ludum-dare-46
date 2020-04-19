using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveOnPlay : MonoBehaviour
{
    void Update()
    {
        if (LevelManager.instance.isPlaying)
        {
            Destroy(gameObject);
        }
    }
}
