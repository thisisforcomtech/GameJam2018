using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarController : MonoBehaviour {

    void Start()
    {
        // Set the bullet to destroy itself after 1 seconds
        Destroy(gameObject, 3.0f);
        // Push the bullet in the direction it is facing
    }
}
