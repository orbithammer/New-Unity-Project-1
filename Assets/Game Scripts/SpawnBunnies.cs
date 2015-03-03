using UnityEngine;
using System.Collections;

public class SpawnBunnies : MonoBehaviour {
	public GameObject zombieBunny; //the zombieBunny prefab
	public Transform currentZone; //the drop zone
	float minX; //variables to hold the object bounding box location
	float maxX;
	float minZ;
	float maxZ;
	int litterSize = 8;
	float reproRate = 12f; //base time before respawning
	internal bool canReproduce = true; //flag to control the reproduction of zombie bunnies
//	int currentBunCount = 0; //add the latest count to the total
	public Transform bunHolder; //to parent the instantiated zombie bunnies to
	GameObject gameManager; //the master repository for game info
	public GameObject stork; //the Stork group
	public Animator beak; //the lower beak's animator component
	public Animator bundle; //the bundle's animator component
	LevelManager levelManager; //the script that holds the data between levels

	// Use this for initialization
	void Start () {
		minX = currentZone.position.x - currentZone.localScale.x / 2;
		maxX = currentZone.position.x + currentZone.localScale.x / 2;
		minZ = currentZone.position.z - currentZone.localScale.z / 2;
		maxZ = currentZone.position.z + currentZone.localScale.z / 2;

		gameManager = GameObject.Find ("Game Manager"); //identify and assign the Game Manager object
		if (GameObject.Find ("Level Manager")) {
			levelManager = GameObject.Find ("Level Manager").GetComponent<LevelManager> ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void PopulateGardenBunnies (int count) {
		if (!canReproduce)
			return; //cancel the latest population explosion
		if (count < 100) {//check for the resuming game flag
			count = Random.Range (count * 3 / 4, count + 1); //randomize the count number
			//send the ammount to update the total
			gameManager.SendMessage ("UpdateCount", count, SendMessageOptions.DontRequireReceiver);
		}
		else count-=100;//strip off the extra 100, to resume to level flag
//		print ("zombie Bunnies =" + currentBunCount);
		for (int i = 0; i < count; i++) {
			//create a new zombie prefab in the scene
			GameObject zBunny = (GameObject) Instantiate (zombieBunny, new Vector3 (Random.Range (minX, maxX), 1.0f, Random.Range (minZ, maxZ)), Quaternion.identity); //create a new zombie bunny prefab in the scene
			Vector3 rot = zBunny.transform.localEulerAngles; //make a variable to hold the local Euler (x,y,z) rotation
			rot.y = Random.Range(1,361); //assign a random rotation to the y part of the temporary variable
			zBunny.transform.localEulerAngles = rot; //assign the new rotation
			//randomize the animation clip starting point
			zBunny.GetComponent<Animator>().Play("bunny eat", 0, Random.Range(0.0f,1.0f));
			zBunny.transform.parent = bunHolder; //assign the clone to this object's transform
		}
	}
	IEnumerator StartReproducing(float minTime) {
		//wait for this amount of time before going on
		float adjustedTime;
		if (levelManager)
			adjustedTime = Random.Range (minTime, minTime + levelManager.difficulty);
		else
			adjustedTime = Random.Range (minTime, minTime + 5f);
		yield return new WaitForSeconds (adjustedTime-3f);
		if (canReproduce) { //check the status before continuing after the pause
			stork.SetActive (true); //reactivate the stork
			stork.SendMessage ("Initialize", SendMessageOptions.DontRequireReceiver); //initialize the stork
			stork.audio.Play (); //play the sound effect that signals the repro populating
			yield return new WaitForSeconds (Random.Range (1f, 2f)); //finish the adjusted time
			if (canReproduce) {
				beak.SetBool ("Cue the Beak", true); //trigger the beak drop
				DropBundle ();
				//having waited, make more zombie bunnies
//				PopulateGardenBunnies (litterSize);
				//and start the coroutine again to minTime, but only if there are enough to reproduce
//				if (canReproduce)
				StartCoroutine (StartReproducing (reproRate));
			}
		}
	}
	void DropBundle () {
		bundle.Play ("Bundle Fall"); //start the fall animation
		bundle.transform.parent = null; //remove the bundle from the Stork Group
		bundle.rigidbody2D.isKinematic = false; //turn on the physics
	}
	public void StartCountdown(){
		int tempLitterSize = litterSize * 3; //increased for the first drop only
		PopulateGardenBunnies (tempLitterSize); //create new zombie prefabs in the scene
		float tempRate = reproRate * 2; //allow extra time before the first drop
		StartCoroutine (StartReproducing (tempRate)); // start the first timer- pass in reproRate seconds
	}
	public void RestartCountdown(){
		if (levelManager)
			StartCoroutine (StartReproducing (reproRate + levelManager.difficulty));
		else
			StartCoroutine (StartReproducing (reproRate));
	}
}