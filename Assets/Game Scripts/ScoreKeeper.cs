using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	internal int currentBunCount = 0; //the current number of zombie bunnies
	public GameObject bunnyCounter; //GUI text object
	int killCount = 0; //player hits
	int hitsRequired = 10; //hits required for the reward
	public PotatoLauncher launcher; //the potato launcher script
	public SpawnBunnies spawner; //the SpawnBunnies script
	public int stopPopX = 1; //variable for stopping extra zombie bunny drops
	public EndGameGUI endGameGUI; //the script that handles the GUI
	public AudioSource munching;//the sound effect compnent for the overrun garden

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void UpdateCount (int adjustment) {

		currentBunCount += adjustment; //add or subtract the number passed in
		bunnyCounter.guiText.text = currentBunCount.ToString(); //change the GUI text's text

		if (currentBunCount == 0) { //garden secure
			if (munching)
				munching.enabled = false;;//turn off the munching sound
			GardenSecure ();
			return;
		}
		if (currentBunCount <= stopPopX) { //stop the population explosion
			//stop the battery drain - the threat is almost neutralized
			GameObject.Find ("Battery Life").GetComponent<BatteryHealth>().trackingBattery = false;
			spawner.canReproduce = false;
		}
		if (launcher.loadRate < 0.2f)
			return; //no rewards available
		//manage player rewards
		if (adjustment == -1) { //if it is a removal
			killCount ++; //increment the count
			int remainder = killCount % hitsRequired; //do the calculation
//			print("remainder = " + remainder + ", " + killCount + " dead");
			if (remainder == 0 && killCount >0) {
				launcher.SendMessage("RewardTime", SendMessageOptions.DontRequireReceiver);
//				print("current rate: " + launcher.loadRate);
			}
//		print ("new count: " + currentBunCount);
		}
	}
	void GardenSecure() {
		//if game over
		endGameGUI.TriggerMessage ("Garden Secure");
		//if more gardens
		//if more levels
	}
	public void StopTheMaddness(int bunCount){
		if(bunCount<=stopPopX){
			//stop the battery drain and refresh GUI
			BatteryHealth batteryHealth=GameObject.Find("Battery Life").GetComponent<BatteryHealth>();
			batteryHealth.trackingBattery=false;
			batteryHealth.UpdateBattery();
			//stop bun drop
			spawner.canReproduce=false;
		}
	}
}
