using UnityEngine;
using System.Collections;

public class SettingsGUI : MonoBehaviour {
	public GUISkin newSkin; //custom skin to use
	float diffSliderValue = 5.0F; //difficulty slider
	float ambSliderValue = 1.0f; //ambient volume slider

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.skin = newSkin;
		//constrain all drawing to be within a 600x600 pixel area
		GUI.BeginGroup (new Rect (Screen.width / 2 - 300, Screen.height / 2 - 350, 600, 600));
		//draw abox in the new coordinate space defined by the BeginGroup
		GUI.Box (new Rect (0, 0, 600, 600), "Settings");
		int y = 240; //base Y position
		int x = 200; //base X inset
		int yOffset = 60; //y offset
		//difficulty slider
		GUI.Label (new Rect (x - 50, y, 300, 60), "Difficulty");
		y += yOffset;
		diffSliderValue = GUI.HorizontalSlider (new Rect (x, y, 200, 60), diffSliderValue, 10.0f, 0f);
		y += yOffset - 25;
		//ambient volume slider
		GUI.Label (new Rect (x - 50, y, 300, 60), "Ambient Sound Volume");
		y += yOffset;
		ambSliderValue = GUI.HorizontalSlider (new Rect (x, y, 200, 60), ambSliderValue, 0f, 1f);
		if (GUI.Button (new Rect (200, y + 60, 200,40), "Main Menu")) {
			//back to main menu
			Application.LoadLevel ("MainMenu");
		}

			
		//must match all BeginGroup calls with an EndGroup
		GUI.EndGroup ();
		if (GUI.changed) {
			audio.volume = ambSliderValue;//adjust the audio clip's volume
		}
//		print (diffSliderValue + " " + ambSliderValue);
	}
}
