using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{

    public KeyCode keyToPress;

    public GameObject effectNormal;
    public GameObject effectGood;
    public GameObject effectPerfect;
    public GameObject effectMiss;

    private Transform activator;
    private bool canBePressed;

    void Update()
    {
        if (canBePressed && Input.GetKeyDown(keyToPress) && LevelManager.instance.canMove)
        {
            canBePressed = false;
            gameObject.SetActive(false);
            float distanceFromActivator = Vector3.Distance(activator.position, transform.position);
            if (distanceFromActivator <= 0.05)
            {
                LevelManager.instance.MoveHitPerfect();
                Instantiate(effectPerfect, transform.position, effectPerfect.transform.rotation);
            }
            else if (distanceFromActivator <= 0.25)
            {
                LevelManager.instance.MoveHitGood();
                Instantiate(effectGood, transform.position, effectGood.transform.rotation);
            }
            else
            {
                LevelManager.instance.MoveHitNormal();
                Instantiate(effectNormal, transform.position, effectNormal.transform.rotation);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Activator")
        {
            activator = collider.transform;
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (canBePressed && collider.tag == "Activator")
        {
            canBePressed = false;
            gameObject.SetActive(false);
            LevelManager.instance.MoveMissed();
            Instantiate(effectMiss, transform.position, effectMiss.transform.rotation);
        }
    }

}
