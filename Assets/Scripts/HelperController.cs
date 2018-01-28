using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperController : MonoBehaviour {

    GameObject shipControllerObject;

    public float myPosX;
    public float myPosY;

    // Use this for initialization
    void Start () {
        shipControllerObject = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		syncRotation();
		syncPosition();
	}

    void syncRotation()
    {
        transform.rotation = shipControllerObject.transform.rotation;
    }

    void syncPosition()
    {
        Vector3 playerPos = shipControllerObject.transform.position;
        transform.position = new Vector3(playerPos.x + myPosX, playerPos.y + myPosY, transform.position.z);
    }
}
