using UnityEngine;
using System.Collections;

public class SensorDoors : MonoBehaviour {
	public AnimationClip clipOpen; //the open animation
	public AnimationClip clipClose; //the close animation
//	public SmoothFollow follow; //the camera's SmoothFollow script
	//variable that can trigger 'game on'
	public bool canActivateGame = false;
	//objects that must be informed of the 'game on' state
	public GameObject gardenHud; //where the battery sprites are & text controlled
	public SpawnBunnies bunnySpawner; //the SpawnBunnies script
	public BatteryHealth batteryLife; //the script for the battery charge (on Battery Life object)
	LevelManager levelManager;//the script that holds the data between levels

	// Use this for initialization
	void Start () {
		if (GameObject.Find ("Level Manager")) {
			levelManager = GameObject.Find ("Level Manager").GetComponent<LevelManager> ();
			if(levelManager.gameState<1)levelManager.gameState=1;//in staging area
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	//open the gates
	void OnTriggerEnter(Collider defender) {
		if (defender.gameObject.tag == "Player") {
//			follow.distance = 1.15f; //change the SmoothFollow distance
//			follow.height = 0.5f; //change the SmoothFollow distance
			animation.Play(clipOpen.name);
			audio.Play ();//play the clip in the audio component
		}
	}
	//close the gates
	void OnTriggerExit(Collider defender) {
		if (defender.gameObject.tag == "Player") {
//			follow.distance = 2.8f; //revert the SmoothFollow distance
//			follow.height = 1.8f; //revert the SmoothFollow distance
			animation.Play(clipClose.name);
			audio.Play ();//play the clip in the audio component
			if (canActivateGame) SetGameOn();//get the game underway
		}
	}
	void SetGameOn(){
		//turn off the flag
		canActivateGame = false;
		//activate the Garden HUD sprites
		gardenHud.GetComponent<ChildVisibility> ().SpriteToggle (true);
		//send a message to start the additional bunny drops
		bunnySpawner.StartCountdown ();
		//set battery drain on
		batteryLife.trackingBattery = true;
		//game is running, inform the LevelManager
		if (levelManager)
			levelManager.gameState = 2;
	}
}