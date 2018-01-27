using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesController : MonoBehaviour {

	// Use this for initialization
	GameObject ChildGameObject1;
	void Start () {
		ChildGameObject1 = this.transform.GetChild (0).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
			//this.transform.position = ChildGameObject1.transform.position;
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Boomed");
        }
    }
}
