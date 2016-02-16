using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {
	bool paused = false;
	string currentScene="Game";
	GameObject loadingText=null;
	int score=0;

	
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this);
		score = PlayerPrefs.GetInt("score");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		loadingText = GameObject.Find ("LoadingText");
	}

	void Start () {
		loadingText.GetComponent<GUIText>().enabled = false;
		LoadNextScene();

	}
	



	void GameOver() {
		PlayerPrefs.SetInt("score", score);
	}


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
			Application.Quit();
		}
		if (Input.GetKeyDown(KeyCode.P)) {
			if (!paused) {
				Time.timeScale =0;
				paused=true;
			}
			else {
				Time.timeScale = 1;
				paused=false;
			}
		}
	}


	void OnDestroy() {
		PlayerPrefs.Save();
	
	}


	
	string NextSceneName() {
		string nextScene="Game";

		if (currentScene=="Game")
			nextScene = "MainMenu";
		else if (currentScene == "MainMenu")
			nextScene = "Level";
		else if (currentScene == "Level")
			nextScene = "MainMenu";
		return nextScene;
	}
	
	public void LoadNextScene() {
		currentScene = NextSceneName();
		loadingText.GetComponent<GUIText>().enabled=true;
		Application.LoadLevel(currentScene);
		loadingText.GetComponent<GUIText>().enabled = false;


	}
	
	void DisplayLoading() {
	}

	void IncreaseScore(int amount) {
		score += amount;
	}
}
