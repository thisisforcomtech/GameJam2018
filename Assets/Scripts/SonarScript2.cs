using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarScript2 : MonoBehaviour
{
    public float maxSize;
    public float growFactor;
    public float waitTime;

    void Start()
    {
        //this.GetComponent<MeshRenderer>().material.color = new Color(1, 0.92f, 0.016f, 0.1f);
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        float timer = 0;

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

        Destroy(gameObject);
    }
}