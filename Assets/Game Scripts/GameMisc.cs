using UnityEngine;
using System.Collections;

public class GameMisc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//prevent baby zombie bunnies from colliding with bundle
		Physics2D.IgnoreLayerCollision (8, 9, true);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			Screen.showCursor = true; //show the cursor
			Application.LoadLevel (1); //load the Main Menu
		}
	}
}
