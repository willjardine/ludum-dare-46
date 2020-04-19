using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookieLoo : MonoBehaviour
{

    public Transform obj;
    public Transform orig;
    public Transform goal;
    public float speed = 1f;
    public float showAt = 0.5f;

    private List<Transform> moves = new List<Transform>();
    private float top = 0f;

    void Start()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Bounds boxBounds = boxCollider.bounds;
        top = boxBounds.center.y + boxBounds.extents.y;
    }

    void Update()
    {
        float percent = 1f;

        // figure out the percentage of closest guy
        if (moves.Count > 0)
        {
            float closestDistance = top;
            float distance = 0f;
            foreach (Transform move in moves)
            {
                distance = Vector3.Distance(move.position, transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                }

            }
            percent = closestDistance / top;
            if (percent <= showAt)
            {
                percent = 0f;
            }
            else
            {
                percent = 1f;
            }
        }

        // move object around
        float step = speed * Time.deltaTime; // calculate distance to move
        Vector3 targetPos = Vector3.Lerp(goal.position, orig.position, percent);
        obj.position = Vector3.MoveTowards(obj.position, targetPos, step);


    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Move")
        {
            moves.Add(collider.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Move")
        {
            moves.Remove(collider.transform);
        }
    }

}
