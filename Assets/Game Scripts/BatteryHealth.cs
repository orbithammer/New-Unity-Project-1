using UnityEngine;
using System.Collections;

public class BatteryHealth : MonoBehaviour {
	public float batteryFull = 70.0f; //battery life in seconds
	internal float batteryRemaining; //remaining battery life in seconds
	int percentRemaining; //converted to percent
	internal bool trackingBattery = false; //timer not started
	GUIText guiTxt; //the GUI text component
	public GameObject energyBar; //the battery's energy bar sprite
	float baseScale; //the energy bar's base y scale
	public EndGameGUI endGameGUI; //the script that handles the GUI

	// Use this for initialization
	void Start () {
		batteryRemaining = batteryFull; //full charge
		guiTxt = GetComponent<GUIText> (); //the GUI text object
		guiTxt.text = "100%"; //full charged-assigned
		baseScale = energyBar.transform.localScale.y; //get the base scale

	}
	
	// Update is called once per frame
	void Update () {
		if (trackingBattery) {
			if (batteryRemaining > 0) {

				UpdateBattery(); //update the sprite graphic
			

				guiTxt.text = percentRemaining.ToString () + "%";
			}
			else {
				GameOver(); //it has run out
				trackingBattery = false; //turn off battery timer
			}
		}
	}

	public void UpdateBattery() {
		batteryRemaining -= Time.deltaTime; //second countdown
		percentRemaining = (int)((batteryRemaining / batteryFull) * 100); //round off for percent

		//animate the battery's energy bar sprite to match percent remaining
		//if less than 50% and greater than 25%, adjust color- raise red to get yellow
		if (percentRemaining <= 50 && percentRemaining > 25) {
			float adj = (50 - percentRemaining) * 0.04f; //adjusted for current position
			energyBar.GetComponent<SpriteRenderer>().color = new Color(1f + adj,1f,0f);
		}
		//if less than or equal to 25%, adjust color drop green to get red
		if (percentRemaining <= 25) {
			float adj = (25 - percentRemaining) * 0.04f;
			energyBar.GetComponent<SpriteRenderer>().color = new Color(1f,1f-adj,0f);

		}
		//adjust battery's energy bar sprite
		Vector3 adjustedScale = energyBar.transform.localScale; //store the sprite's scale in a temp var
		adjustedScale.y = baseScale * (batteryRemaining / batteryFull); //calculate the actual y scale
		energyBar.transform.localScale = adjustedScale; //apply the new value
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
		//end of game options
		endGameGUI.TriggerMessage ("Garden Overrun");
	}
}
