using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Endgame : MonoBehaviour {
    GameObject gamecontroller;
    public Text RescuredScore;
    public Text LostScore;
    // Use this for initialization
    void Start () {
        gamecontroller = GameObject.FindWithTag("GameController");
    }
	
	// Update is called once per frame
	void Update () {
        RescuredScore.text = "Rescued : " + gamecontroller.GetComponent<GameController>().score;
        LostScore.text = "Lost : " + gamecontroller.GetComponent<GameController>().lost;
    }
}
