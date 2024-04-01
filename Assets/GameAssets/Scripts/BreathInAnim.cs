using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathInAnim : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1.0f;
    public Vector3 posOrigin = new Vector3();
    public Vector3 posTemp = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        posOrigin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posTemp = posOrigin;
        posTemp.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        transform.position = posTemp;
    }
}
