using UnityEngine;
using System.Collections;

public class SensorDoors : MonoBehaviour {
	public AnimationClip clipOpen; //the open animation
	public AnimationClip clipClose; //the close animation
//	public SmoothFollow follow; //the camera's SmoothFollow script

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
	//open the gates
	void OnTriggerEnter(Collider defender) {
		if (defender.gameObject.tag == "Player") {
//			follow.distance = 1.15f; //change the SmoothFollow distance
//			follow.height = 0.5f; //change the SmoothFollow distance
			animation.Play(clipOpen.name);
			audio.Play ();//play the clip in the audio component
		}
	}
	//close the gates
	void OnTriggerExit(Collider defender) {
		if (defender.gameObject.tag == "Player") {
//			follow.distance = 2.8f; //revert the SmoothFollow distance
//			follow.height = 1.8f; //revert the SmoothFollow distance
			animation.Play(clipClose.name);
			audio.Play ();//play the clip in the audio component
		}
	}
}