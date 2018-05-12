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
            control.text = "Controls: \n use the Mouse \n and the W key \n to guild the ship ";
            tapText.text = "press space to send out a sonar \n to see near by asteroids \n and enemy ships";

        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            control.text = "Controls: \n Hold down the direction you wish to go \n to guild your ship";
            tapText.text = "Tap the screen send out a sonar \n to see near by asteroids \n and enemy ships";
        }
    }
}
