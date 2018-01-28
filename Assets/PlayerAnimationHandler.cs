using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
    private Animator animator;
    

    // Use this for initialization
    void Start () {
         animator = this.GetComponent<Animator>();
         animator.SetBool("Started", true);
}
	
	// Update is called once per frame
	void Update () {
        animator.SetFloat("angle",this.transform.eulerAngles.x);
	}
}
