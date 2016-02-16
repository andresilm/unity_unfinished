using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	GameObject gameManager;
	float levelScore=0;
	GUIStyle scoreboardStyle;

	// Use this for initialization
	void Awake () {
		gameManager = GameObject.Find("GameManager");
		if (gameManager == null)
			Debug.Log ("WARNING: GameManager not found.");


	}

	void Start () {
		SetGUI();
	}


	void SetGUI() {
		scoreboardStyle = new GUIStyle();
		scoreboardStyle.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
		levelScore +=  Time.deltaTime;
	}

	void OnGUI() {
		GUI.Label(new Rect(10,10,100,30), "Score: "+ ((int)levelScore).ToString(),scoreboardStyle);
	}

	void IncreaseScoreBy(int amount) {
		levelScore += amount;
	}

	void OnDestroy() {
		//update Score in GameManager
	}
}
