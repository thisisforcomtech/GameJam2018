using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

	[SerializeField]
	private Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] lives = GameObject.FindGameObjectsWithTag("LivesPickup");
        if (lives[0] != null)
        {
			//Vector3 turnRot = lives[0].transform.position - this.transform.position;



			//Quaternion finalRot = Quaternion.LookRotation(turnRot);
			float x = this.transform.position.x - target.position.x;/*lives[0].transform.position.x;*/
			float y = this.transform.position.y - target.position.y;/*lives[0].transform.position.y;*/
			float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
			Quaternion finalRot = Quaternion.Euler(0, 0, (angle - 90));
			transform.rotation = Quaternion.RotateTowards(transform.rotation, finalRot, Time.deltaTime * 30f);


		}
    }
}
