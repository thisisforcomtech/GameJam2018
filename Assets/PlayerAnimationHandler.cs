using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour {
    private Animator animator;
	private float lastAngle;
	private Rigidbody rbody;

    // Use this for initialization
    void Start () {
         animator = this.GetComponent<Animator>();
		rbody = this.GetComponent<Rigidbody>();
		animator.SetBool("Started", true);
		lastAngle = this.transform.rotation.z;

		StartCoroutine("CheckAngleDiff");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		//animator.SetFloat("angle",this.transform.eulerAngles.x);

	
	}

	IEnumerator CheckAngleDiff() {
		for (;;) {
			//float visibleTurnAngle = rbody.velocity.magnitude;

			//visibleTurnAngle *= transform.rotation.z > 0 ? 1 : -1;

			//animator.SetFloat("angle", visibleTurnAngle);


			float diff = transform.rotation.z - lastAngle;

			diff *= 100;

			animator.SetFloat("angle", diff);

			print(rbody.velocity.x);
			lastAngle = this.transform.rotation.z;

			yield return new WaitForSeconds(0.1f);
		}
	}
}
