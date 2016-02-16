using UnityEngine;
using System.Collections;

public class PlayerInputHandle : MonoBehaviour {
	// PUBLIC (para usar desde el Editor)
	public float jumpForce = 350f;
	//PRIVATE
	Animator playerAnimator;
	float initialY;

	float minSwipe;
	Vector2 touchInputStartPosition;
	Vector2 touchDirection;
	bool touchDirectionChosen;

	// Use this for initialization
	void Awake () {
		minSwipe = Screen.height/4.0f;
		playerAnimator = GetComponent<Animator> ();
		initialY = this.transform.position.y;

	}

	void Start () {

	}

	void Update() {
		if (Input.anyKeyDown) {
			HandleKBInput();
		}
		if (Input.touchCount > 0) {
			HandleTouchInput();
		}
	}
		
		// Update is called once per frame
	void FixedUpdate () {
		//Debug.Log("animator onGround:" + playerAnimator.GetBool("onGround").ToString());
		//Debug.Log("physics onGround: "+ OnGround().ToString());
	
		playerAnimator.SetBool("onGround",OnGround());
	}
	void HandleKBInput() {

		if (Input.GetKeyDown(KeyCode.J) && OnGround()) {			
			this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
		}

		if (Input.GetKeyDown(KeyCode.K) && OnGround()) {
			playerAnimator.SetTrigger("Slide");
		}

	


	}


	void HandleTouchInput() {
		Touch touch = Input.GetTouch(0);


		// Handle finger movements based on touch phase.
		switch (touch.phase) {
			// Record initial touch position.
		case TouchPhase.Began:
			touchInputStartPosition = touch.position;
			touchDirectionChosen = false;
			break;
			
			// Determine direction by comparing the current touch
			// position with the initial one.
		case TouchPhase.Moved:
			touchDirection = touch.position - touchInputStartPosition;
			break;
			
			// Report that a direction has been chosen when the finger is lifted.
		case TouchPhase.Ended:
			touchDirectionChosen = true;
			break;
		}

		if (touchDirectionChosen) {

			if (touchDirection.y > minSwipe) {
				this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
			}
			else if (touchDirection.y < -minSwipe){
				//playerAnimator.SetTrigger("Slide");

			}

			touchDirection.Set(0f,0f);
			touchDirectionChosen = false;
		}
	}

	bool OnGround() {
		return this.transform.position.y <= initialY;
	}



}
