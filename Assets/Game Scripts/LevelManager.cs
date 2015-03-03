using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	int currentLevel; //the currently active level
	public int gameState=0;//0,new game, 1,staging area, 2, in garden
	public Vector3 gnomePos;//the gnome's position
	public float gnomeYRot;//the gnome's Y rotation
	internal int bunCount=0;//number of buns in garden
	internal int percentRemaining;//% of battery remaining
	internal float ambientVolume = 0.8f;//volume for all ambient sounds/music
	internal int difficulty=5;//affects battery life
	public bool[] areaVisibility;//active state of the garden areas

	void Awake(){
		DontDestroyOnLoad (transform.gameObject);
	}
	// Use this for initialization
	void Start () {
		print ("Starting " + Application.loadedLevelName);
		currentLevel = Application.loadedLevel;//its index number
		}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel != currentLevel) {
			currentLevel = Application.loadedLevel;
			print ("new level = " + Application.loadedLevel + ", " + Application.loadedLevelName);
			ManageLevels();//do stuff according to the level just entered
		}
	}
	void ManageLevels(){
		ProcessAudio ();//adjust the ambient volume no matter what the level is
		if (currentLevel > 3) {//you are in a garden level
			//set teh occlusion ares' visibility
			GameObject.Find("Game Manager").GetComponent<GameMisc>().LoadVis();
			//reposition & re-orient gnome
			GameObject.Find ("Gnomatic Garden Defender").GetComponent<SetTransform> ().UpdateTransform (gnomePos, gnomeYRot);
			BatteryHealth batteryHealth=GameObject.Find("Battery Life").GetComponent<BatteryHealth>();
				//update full battery value, use inverse, add offset
			float newBattery=(150f*difficulty*0.01f)+25f;
			batteryHealth.UpdateBatteryLife(newBattery,percentRemaining);
			if (gameState == 1)return;//still in staging area, just repopulate a new game
			//game state must be 2, the game is on
			//use the LevelManager's stored values to update and turn on HUD stuff
			GameObject.Find("Game Manager").GetComponent<ScoreKeeper>().currentBunCount=bunCount;
			//update the zombie bunny count in the HUD
			GameObject.Find("Bunny Count").GetComponent<GUIText>().text=bunCount.ToString();
			//repopulate the zombie bunnies and related functionality
			SpawnBunnies spawnBunnies=GameObject.Find ("Zombie Spawn Manager").GetComponent<SpawnBunnies>();
			//repopulate the zombie bunnies, adding 100 as a flag not to randomize
			spawnBunnies.PopulateGardenBunnies(bunCount+100);//repopulate
			//restart the drop timer
			spawnBunnies.RestartCountdown();
			//manage the battery HUD
//			batteryHealth.batteryRemaining=batteryRemaining;
			batteryHealth.trackingBattery=true;//restart the drain
			//turn on battery sprites again
			GameObject.Find("Garden HUD").GetComponent<ChildVisibility>().SpriteToggle(true);
			GameObject.Find("Camera GUI").GetComponent<GUILayer>().enabled=true;//activate GUI Text
			GameObject.Find("Game Manager").GetComponent<ScoreKeeper>().StopTheMaddness(bunCount);
		}
	}
	void ProcessAudio(){
		GameObject[] ambientTags=GameObject.FindGameObjectsWithTag("Ambient");
		foreach (GameObject ambientTag in ambientTags){
			ambientTag.audio.volume = ambientVolume;
		}
	}
}
