using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour {

    public Texture[] Scenes;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void changeScene(int scene)
    {

        this.GetComponent<RawImage>().texture = Scenes[scene-1];
    }
    
}
