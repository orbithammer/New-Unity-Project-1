using UnityEngine;
using System.Collections;

public class CreditsGUI : MonoBehaviour {
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
			int y = 240; //base Y position
			int x = 150; //base x inset
			int yOffest = 60; //y offset
		y += yOffest;
		//title
		GUI.Label (new Rect (x, y, 300, 60), "Game Design","left_label");

		//person
		GUI.Label (new Rect (x, y, 300, 60), "Brock Penner","right_label");
		y += yOffest;
		//date
		GUI.Label (new Rect (x, y, 300, 60), "TK");
		y += yOffest;
		//main menu
		if (GUI.Button (new Rect (200,420, 200, 40), "Main Menu")) {
			//back to main menu
			Application.LoadLevel("MainMenu");
		}
		//must match all BeginGroup calls with an EndGroup
		GUI.EndGroup ();
	}
}
