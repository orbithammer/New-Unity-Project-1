using UnityEngine;
using System.Collections;

public class FlyBy : MonoBehaviour {
	public float speed = -5f; //send the 2d sprite left
	Vector3 startLocation; //starting spot
	Vector3 endLocation; //out of view
	float offSetX = -25f; //distance to the other side

	void Awake () {
		startLocation = transform.position; //store the starting location
		endLocation = new Vector3 (startLocation.x + offSetX, startLocation.y, startLocation.z);
	}

	// Use this for initialization
	void Start () {
		Initialize (); //set location
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.localPosition.x < endLocation.x)
			gameObject.SetActive (false); //deactivate
		transform.Translate (speed * Time.deltaTime, 0, 0);
	}
	void Initialize() {
		//reset the start location
		Vector3 tempLocation = transform.position; //make a variable to hold the value
		tempLocation = startLocation; //change the value
		transform.position = tempLocation; //assign the new value
	}
}
