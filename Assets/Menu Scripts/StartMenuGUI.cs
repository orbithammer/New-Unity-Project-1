using UnityEngine;
using System.Collections;

public class StartMenuGUI : MonoBehaviour {
	public GUISkin newSkin; //custom skin to use
	int screenW; //screen width
	int screenH; //screen height

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI(){
		GUI.skin = newSkin;
		//manage layout
//		print (Screen.height);
		screenW = Screen.width;
		screenH = Screen.height;
		int yOffset = 30; //default offset
		if (screenH < 800)
			yOffset = screenH / 50; //adjusted offset
		//constrain all drawing to be within a 500x500 pixel area centered on the screen
		GUI.BeginGroup (new Rect (screenW / 2 - 250, screenH - screenH / 2 - 150, 500, 500));
		//add controls here
		int ySize = 64; //button width
		int xSize = 400; //button height
		int y = 150 + yOffset * 3; //adjust the starting vertical location according to screen size
		int x = 250 - xSize / 2; //the horizontal location
		//play game
		if (GUI.Button (new Rect (x, y, xSize, ySize), "Play Game")) {
			//start game
			Screen.showCursor = false; //hide the cursor
			Application.LoadLevel ("GardenLevel1");
		}
		y += ySize + yOffset;
		//settings
		if (GUI.Button (new Rect (x, y, xSize, ySize), "Main Menu")) {
			//go to settings menu
			Application.LoadLevel ("MainMenu");
		}
		y += ySize + yOffset;
		//quit
		if (GUI.Button (new Rect (x, y, xSize, ySize), "Quit")) {
			//quit application
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
		//must match all BeginGroup calls with an EndGroup
		GUI.EndGroup ();
	}
}
