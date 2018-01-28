using UnityEngine;
using System.Collections;

public class SonarController : MonoBehaviour
{
    Quaternion rot;
    Renderer rend;
    // Use this for initialization
    void Start()
    {

    }
    public void run()
    {
        rot = transform.rotation;
        // Push the bullet in the direction it is facing
        StartCoroutine(Example());
    }
    IEnumerator Example()
    {

        GetComponent<Rigidbody>().velocity = -transform.forward * 10f;
        print(Time.time);
        yield return new WaitForSeconds(1);
        print(Time.time);
        transform.rotation = rot;
        GetComponent<Rigidbody>().velocity = transform.forward * 10f;
    }
    void OnTriggerEnter(Collider c)
    {

        // Anything except a bullet is an asteroid
        if (c.gameObject.tag == "Radar" )
        {

            this.transform.position = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color", Color.white);
        }
        else if (c.gameObject.tag == "LivesPickup")
        {
        	rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_Color",Color.red);
        }
    }
}