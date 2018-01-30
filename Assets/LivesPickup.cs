using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesPickup : MonoBehaviour {

    public GameObject blip;
    public bool bliping = false;
    public bool die = false;
    public float maxSize;
    public float growFactor;
    public float waitTime;
    public Color color;
    public bool retry;
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
            spawnBlip(die, maxSize, growFactor, waitTime, color);
            bliping = true;
        }
        if (retry)
            bliping = false;
    }
    public void spawnBlip(bool die, float maxSize, float growFactor, float waitTime, Color color)
    {
        GameObject G = Instantiate(blip, this.transform.position, this.transform.rotation);
        G.GetComponent<MeshRenderer>().material.color = color;
        G.transform.parent = this.transform.parent;
        G.GetComponent<BlipScript>().willDie = die;
        G.GetComponent<BlipScript>().maxSize = maxSize;
        G.GetComponent<BlipScript>().growFactor = growFactor;
        G.GetComponent<BlipScript>().waitTime = waitTime;
    }
}
