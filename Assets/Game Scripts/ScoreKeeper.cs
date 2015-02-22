using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	int currentBunCount = 0; //the current number of zombie bunnies

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateCount (int adjustment) {

		currentBunCount += adjustment; //add or subtract the number passed in
		print ("new count: " + currentBunCount);
	}
}
