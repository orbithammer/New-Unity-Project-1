using UnityEngine;
using System.Collections;

public class ReceivedHit : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter (Collision collision) {
		if (collision.transform.tag == "Ammo") {
			//if it was hit by something tagged as Ammo, process its destruction
			DestroyBun ();
		}
	}
	void DestroyBun() {
		Destroy (gameObject, 0.2f); //destroy it after a brief pause
	}
}
