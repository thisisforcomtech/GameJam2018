using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class controlScript : MonoBehaviour {
    public Text control;
    public Text tapText;
	// Use this for initialization
	void Awake () {
        if (Application.platform != RuntimePlatform.Android)
        {
            control.text = "use the Mouse \n and the W key \n to guild your ship ";
            tapText.text = "Press Space to send out a sonar \n to see nearby asteroids \n and ships";

        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            control.text = "Hold down the direction \n you wish to go \n to guild your ship";
            tapText.text = "Double tap to send out a sonar \n to see nearby asteroids \n and ships";
        }
    }
}
