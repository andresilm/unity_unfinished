using UnityEngine;
using System.Collections;

public class MainScreen : MonoBehaviour {
	GameObject manager=null;
	// Use this for initialization
	void Awake () {
		manager = GameObject.Find("GameManager");

		if (manager==null) {
			Debug.Log ("WARNING: GameManager not found.");
		}

	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			manager.SendMessage("LoadNextScene");
		}
	}
}
