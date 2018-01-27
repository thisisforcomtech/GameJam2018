using UnityEngine;
using System.Collections;

public class SonarController : MonoBehaviour
{
    Quaternion rot;
    Renderer rend;
    // Use this for initialization
    void Start()
    {
        // Set the bullet to destroy itself after 1 seconds
        rot = transform.rotation;
        // Push the bullet in the direction it is facing
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {

        GetComponent<Rigidbody>().velocity = -transform.forward * 2f;
        print(Time.time);
        yield return new WaitForSeconds(5);
        print(Time.time);
        transform.rotation = rot;
        GetComponent<Rigidbody>().velocity = transform.forward * 2f;
    }
    void OnTriggerEnter(Collider c)
    {

        // Anything except a bullet is an asteroid
        if (c.gameObject.tag == "Radar" )
        {

            Destroy(gameObject);
        }
        else if (c.gameObject.tag == "Large Asteroid")
        {
        	rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor",Color.red);
        }
    }
}