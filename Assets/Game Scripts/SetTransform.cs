using UnityEngine;
using System.Collections;

public class SetTransform : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void UpdateTransform (Vector3 newPos, float newYRot){
		//set the new position
		Vector3 tempPos = new Vector3 (transform.position.x, transform.position.z);
		tempPos = newPos;
		transform.position = tempPos;
		//set the new y rotation
		Vector3 tempRot = new Vector3 (transform.localEulerAngles.x, transform.localEulerAngles.z);
		tempRot.y = newYRot;
		transform.localEulerAngles = tempRot;
	}
}
