using UnityEngine;
using System.Collections;

public class EndGameGUI : MonoBehaviour {
	string finishedMessage = "Garden Secure"; //message for finished garden
	public GUISkin newSkin; //custom skin to use
	bool showEndGUI = false; //flag to hide/show end message and options
	bool overrideColor = false; //flag for message colors

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI() {
		GUI.skin = newSkin;
		if (overrideColor)
			GUI.color = new Color (0.8f, 0, 0); //a dark red
		if (showEndGUI) {
			GUI.Label (new Rect (Screen.width / 2 - 800, Screen.height / 2 - 250, 1600, 200), finishedMessage);
			GUI.color = Color.white; //return it to white, a pre-defined color
			//Play Again
			if (GUI.Button (new Rect (Screen.width / 2 - 325, Screen.height / 2, 300, 60), "Play Again")) {
				Screen.showCursor = false; //hide the cursor
				Application.LoadLevel ("GardenLevel1");
				//call function here
			}
			//Quit
			if (GUI.Button (new Rect (Screen.width / 2 + 25, Screen.height / 2, 300, 60), "Quit")) {
#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
				//call function here
			}
		} //close end message conditional

	}
	public void TriggerMessage (string results) {
		finishedMessage = results; //set the correct message
		overrideColor = (finishedMessage == "Garden Overrun");
		Screen.showCursor = true; //show the cursor
		showEndGUI = true; //turn on the message
	}
}
