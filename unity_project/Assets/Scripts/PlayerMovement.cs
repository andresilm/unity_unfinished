using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float scrollSpeed = 0.06f;
	float deltaTimeCount=0;
	public float deltaTimeUpdateRate = 1;
	Vector3 initial;
	bool gameFinished=false;


	void Awake() {


	}

	// Use this for initialization
	void Start () {
		initial = this.transform.position;

		//Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
		gameFinished =  Time.timeScale==0;

		if (Time.timeScale!=0 && gameFinished) {
			this.transform.position = initial;
			gameFinished = false;
		}

	}

	void FixedUpdate () {
		deltaTimeCount += 1;
		if (deltaTimeCount >= deltaTimeUpdateRate) {
			float x = this.transform.position.x;
			float y = this.transform.position.y;
			float z = this.transform.position.z;

			this.transform.position = new Vector3(x+scrollSpeed,y,z);
			deltaTimeCount = 0;
		}


	}
}
