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
	bool canReproduce = true; //flag to control the reproduction of zombie bunnies
	int currentBunCount = 0; //add the latest count to the total

	// Use this for initialization
	void Start () {
		minX = currentZone.position.x - currentZone.localScale.x / 2;
		maxX = currentZone.position.x + currentZone.localScale.x / 2;
		minZ = currentZone.position.z - currentZone.localScale.z / 2;
		maxZ = currentZone.position.z + currentZone.localScale.z / 2;
		int tempLitterSize = litterSize * 3; //increased for the first drop only
		PopulateGardenBunnies (tempLitterSize); //create new zombie prefabs in the scene
		float tempRate = reproRate * 2; //allow extra time before the first drop
		StartCoroutine(StartReproducing(tempRate)); // start the first timer- pass in reproRate seconds
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void PopulateGardenBunnies (int count) {
		count = Random.Range (count * 3 / 4, count + 1); //randomize the count number
		currentBunCount += count;
		print ("zombie Bunnies =" + currentBunCount);
		for (int i = 0; i < count; i++) {
			//create a new zombie prefab in the scene
			GameObject zBunny = (GameObject) Instantiate (zombieBunny, new Vector3 (Random.Range (minX, maxX), 1.0f, Random.Range (minZ, maxZ)), Quaternion.identity); //create a new zombie bunny prefab in the scene
			Vector3 rot = zBunny.transform.localEulerAngles; //make a variable to hold the local Euler (x,y,z) rotation
			rot.y = Random.Range(1,361); //assign a random rotation to the y part of the temporary variable
			zBunny.transform.localEulerAngles = rot; //assign the new rotation
			//randomize the animation clip starting point
			zBunny.GetComponent<Animator>().Play("bunny eat", 0, Random.Range(0.0f,1.0f));
		}
		}
	IEnumerator StartReproducing(float minTime) {
		//wait for this amount of time before going on
		float adjustedTime = Random.Range (minTime, minTime + 5);
		yield return new WaitForSeconds (adjustedTime-3f);
		audio.Play (); //play the sound effect that signals the repro populating
		yield return new WaitForSeconds (3f); //finish the adjusted time
		//having waited, make more zombie bunnies
		PopulateGardenBunnies (litterSize);
		//and start the coroutine again to minTime, but only if there are enough to reproduce
		if (canReproduce)
			StartCoroutine (StartReproducing (reproRate));
	}
}

