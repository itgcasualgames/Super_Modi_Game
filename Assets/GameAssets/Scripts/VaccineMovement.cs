using System.Collections;
using System.Collections.Generic;
using Bapk;
using UnityEngine;

public class VaccineMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject target;
   
    public bool reached;

    void Update()
    {
        float step = speed * Time.deltaTime;
        if(!reached)
        // move sprite towards the target location
        { 
        if(transform.position!=target.transform.position)
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
         if (transform.position.y == target.transform.position.y)
            {
                reached = true;
                target.GetComponent<Animation_Script>().enabled = true;
                gameObject.SetActive(false);
            }
        }

    }
}
