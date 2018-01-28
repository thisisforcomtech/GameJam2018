using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesPickup : MonoBehaviour {

    public GameObject blip;
    public bool bliping = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Sonar") && !bliping)
        {
            GameObject G = Instantiate(blip, this.transform.position, this.transform.rotation);
            G.GetComponent<MeshRenderer>().material.color = new Color(0f, 1f, 0f, 0.2f);
            G.transform.parent = this.transform.parent;
            bliping = true;
        }
    }
}
