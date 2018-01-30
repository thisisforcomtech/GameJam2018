﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlipScript : MonoBehaviour
{
    public float maxSize;
    public float growFactor;
    public float waitTime;
    public bool willDie = false;

    void Start()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        float timer = 0;

        while (true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while (maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer

            yield return new WaitForSeconds(waitTime);

            timer = 0;
            while (1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            if (!willDie)
            {
                timer = 0;
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}