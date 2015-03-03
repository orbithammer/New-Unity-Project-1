using UnityEngine;
using System.Collections;

public class GameMisc : MonoBehaviour {
	LevelManager levelManager;//the script that holds the data between levels
	public Transform gnomeTransform;//the gnome's variables
	//needed for level hopping
	public ScoreKeeper scoreKeeper;//where the current bun count is kept (on the game manager)
	public BatteryHealth batteryHealth;//where the battery charge is tracked (on the Battery Life)


	// Use this for initialization
	void Start () {
		//prevent baby zombie bunnies from colliding with bundle
		Physics2D.IgnoreLayerCollision (8, 9, true);
		if(GameObject.Find("Level Manager")){
			levelManager=GameObject.Find("Level Manager").GetComponent<LevelManager>();
			//if this is a new game, send the inital data
			if(levelManager.gameState==0)LevelPrep();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.F1)) {
			Screen.showCursor = true; //show the cursor
				LevelPrep();//do data collection before going to the new level
//			Application.LoadLevel ("Main Menu"); //load the Main Menu
				StartCoroutine(LoadTheLevel());
		}
	}
	void LevelPrep(){
			if(levelManager){
				//send the gnome's transform off to be saved if the levelManager has been found
				Transform temptrans=gnomeTransform;
				levelManager.gnomePos=temptrans.position;
				levelManager.gnomeYRot=temptrans.localEulerAngles.y;
				//send the current zombie bunnie count
			levelManager.bunCount=scoreKeeper.currentBunCount;
			//send the battery info
			levelManager.batteryRemaining=batteryHealth.batteryRemaining;
			}
		}
		IEnumerator LoadTheLevel(){
			//makes sure all the storage tasks have been completed
			yield return new WaitForSeconds(0.1f);
			Application.LoadLevel("MainMenu");//load the Main Menu
		}
		}
