using UnityEngine;
using System.Collections;

public class BatteryHealth : MonoBehaviour {
	public float batteryFull = 70.0f; //battery life in seconds
	float batteryRemaining; //remaining battery life in seconds
	int percentRemaining; //converted to percent
	bool trackingBattery = true; //timer not started
	GUIText guiTxt; //the GUI text component

	// Use this for initialization
	void Start () {
		batteryRemaining = batteryFull; //full charge
		guiTxt = GetComponent<GUIText> (); //the GUI text object
		guiTxt.text = "100%"; //full charged-assigned
	
	}
	
	// Update is called once per frame
	void Update () {
		if (trackingBattery) {
			if (batteryRemaining > 0) {
				batteryRemaining -= Time.deltaTime; //second countdown
				percentRemaining = (int)((batteryRemaining / batteryFull) * 100); //round off for percent
				guiTxt.text = percentRemaining.ToString () + "%";
			}
			else {
				GameOver(); //it has run out
				trackingBattery = false; //turn off battery timer
			}
		}
	}
	void GameOver(){
		//deactivate the potato gun firing
		GameObject.Find ("Fire Point").SetActive (false);
		//disable navigation
		GameObject.Find ("Gnomatic Garden Defender").GetComponent<CharacterMotor> ().enabled = false;
		//disable turning
		GameObject.Find ("Gnomatic Garden Defender").GetComponent<MouseLook> ().enabled = false;
		//disable weapon aiming
		GameObject.Find ("Arm Group").GetComponent<MouseLook> ().enabled = false;
	}
}
