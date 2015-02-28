using UnityEngine;
using System.Collections;

public class BabyZBHandler : MonoBehaviour {
	Vector3 startLocation; //the objects's original location
	float zRotation; //the object's original z location
	GameObject bundle; //the bundle
	GameObject stork; //the stork

	void Awake() {
		startLocation = transform.localPosition; //store the starting location
		zRotation = transform.localEulerAngles.z;
		stork = GameObject.Find ("Stork Group"); //locate the parent object
		bundle = GameObject.Find ("Bundle"); //locate the parent object
	}

	// Use this for initialization
	void Start () {
		transform.parent = bundle.transform; //move the baby zb into the bundle group
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Escape(){
		//unparent the object
		transform.parent = null;
		//turn on the physics!
		rigidbody2D.isKinematic = false;
		//add some spin
		rigidbody2D.AddTorque(Random.Range(-50f,50f)); //on the z, the only option for 2D torque
		//bounce the bun up with a random x force and random y force
		rigidbody2D.AddForce(new Vector2(Random.Range(-100f,100f),Random.Range(-200f,700f)));
		//start the corouine that will manage the reset
		StartCoroutine(Deactivator());
	}
	IEnumerator Deactivator () {
		yield return new WaitForSeconds (Random.Range (4f, 5f)); //wait 4 to 5 seconds
		//turn off the physics
		rigidbody2D.isKinematic = true;
		rigidbody2D.velocity = Vector2.zero; //clear the velocity
		rigidbody2D.angularVelocity = 0; //clear the spin velocity
		//add the bundle back into the Stork Group's transform
		transform.parent = stork.transform;
		//reset the start posiion
		transform.localPosition = startLocation;
		//reset the rotation
		Vector3 tempRot = transform.localEulerAngles;
		tempRot.z = zRotation;
		transform.localEulerAngles = tempRot;
		transform.parent = bundle.transform; //move the baby zb into the bundle group

	}
}
