using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	Animator ballAnimator;
	Animator playerAnimator;
	// Use this for initialization
	void Awake () {
		ballAnimator = GetComponent<Animator> ();
		playerAnimator =  this.transform.parent.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ballAnimator.SetBool("onPlayerFoot",!playerAnimator.GetBool("onGround"));
	}

	void HandleUserInput() {
		if (playerAnimator) {
			ballAnimator.SetBool("onPlayerFoot",true);
		}
	}
}
