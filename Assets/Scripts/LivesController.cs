using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	[SerializeField]
	private Renderer mesh; 

	// Use this for initialization
	void Start () {
        mesh.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
			//this.transform.position = ChildGameObject1.transform.position;
	}

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    Destroy(gameObject);
        //}
        if (other.gameObject.tag == "Sonar")
        {
           mesh.enabled = true;
        }
    }
}
