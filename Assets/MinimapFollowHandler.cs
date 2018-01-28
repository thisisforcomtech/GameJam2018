using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapFollowHandler : MonoBehaviour {

	[SerializeField]
	private Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 newPosition = target.position;
		newPosition.z = transform.position.z;

		transform.position = newPosition;
	}
}
