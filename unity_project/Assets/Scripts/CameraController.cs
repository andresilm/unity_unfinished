using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	 Transform player;
	 float locationOnScreen = 2;
	// Use this for initialization
	void Awake () {
		locationOnScreen = 2;
		player = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		float z = this.transform.position.z;
		float y = this.transform.position.y;
		this.transform.position = new Vector3(player.position.x + locationOnScreen,y,z);
	}
}
