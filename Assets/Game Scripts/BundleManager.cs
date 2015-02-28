using UnityEngine;
using System.Collections;

public class BundleManager : MonoBehaviour {
	public GameObject stork; //the Stork Group object
	Vector3 startLocation; //the bundle's original location
	public Animator animator; //the bundle's animator component
	public int litterSize = 8; //Maximum litter size on spawning
	public GameObject zSpawnManager; //where the SpawnBunnies script is
	GameObject[] buns2D; //array to hold he baby buns sprites

	void Awake () {
		startLocation = transform.localPosition; //store the starting location
		buns2D = GameObject.FindGameObjectsWithTag ("Buns2D");
	}

	// Use this for initialization
	void Start () {
		Initialize (); //set location
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Initialize () {
		//set the animation state back to Bundle Carry clip/state
		animator.Play ("Bundle Carry");
	}
	void OnCollisionEnter2D () {
		foreach (GameObject bun2d in buns2D) {
			bun2d.GetComponent<BabyZBHandler> ().Escape ();
		}
		animator.Play ("Bundle Open"); //trigger the open clip
		StartCoroutine (Deactivator ()); //start the coroutine
		zSpawnManager.SendMessage ("PopulateGardenBunnies", litterSize, SendMessageOptions.RequireReceiver);
	}
	IEnumerator Deactivator () {
		yield return new WaitForSeconds (3.5f); //wait 3.5 seconds
		//turn off 2D physics
		rigidbody2D.isKinematic = true;
		//add the bundle back into the Stork group's transform
		transform.parent = stork.transform;
		//reset the start position
		Vector3 tempLocation = transform.position;
		tempLocation = startLocation;
		transform.localPosition = tempLocation;
	}
}
