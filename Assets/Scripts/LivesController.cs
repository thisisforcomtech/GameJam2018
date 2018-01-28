using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
			//this.transform.position = ChildGameObject1.transform.position;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Sonar")
        {
            GetComponent<Renderer>().enabled = true;
        }
    }
}
