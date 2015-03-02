using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {
	public GUISkin newSkin; //custom skin to use

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
			//draw a box in the new coordinate space defined by the BeginGroup
			GUI.Box (new Rect (0, 0, 600, 600), "Main Menu");
			int y = 265; //base Y position
			int x = 200; //base x inset
			int yOffest = 60; //y offset
			//play game
			if (GUI.Button (new Rect (x, y, 200, 40), "Play / Resume")) {
				//start game
				Screen.showCursor = false; //hide the cursor
				Application.LoadLevel ("GardenLevel1");
		}
		y += yOffest;
		//settings
		if (GUI.Button (new Rect (x, y, 200, 40), "Settings")) {
			//got to settings menu
			Application.LoadLevel ("SettingsMenu");
		}
		y += yOffest;
		//credits
		if (GUI.Button (new Rect (x, y, 200, 40), "Credits")) {
			//got to credits
			Application.LoadLevel ("Credits");
		}
		y += yOffest;
		//quit
		if (GUI.Button (new Rect (x, y, 200, 40), "Quit")) {
			//quit application
			Application.Quit ();
		}
		//must match all BeginGroup calls with an EndGroup
		GUI.EndGroup ();
	}
}
